using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer
{
    public abstract void OnNotify(); //notifies events and see if it wants to initiate anything
}

public class Enemy : Observer
{
    GameObject enemyObj;
    EnemyEvents enemyEvent;

    public Enemy(GameObject enemyObj, EnemyEvents enemyEvent)
    {
        this.enemyObj = enemyObj;
        this.enemyEvent = enemyEvent;
    }

    public override void OnNotify()
    {
        SpikeColor(enemyEvent.EnemyColor());
    }

    void SpikeColor(Color mat)
    {
        if (enemyObj)
        {
            enemyObj.GetComponent<Renderer>().materials[1].color = mat;
        }
    }
}
