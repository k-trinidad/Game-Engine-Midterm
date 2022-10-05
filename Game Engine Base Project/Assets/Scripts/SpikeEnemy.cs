using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    Subject subject = new Subject();

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player") //if player touches spike
        {
            //access instance and change colour
            EnemyManager.enemyInstance.ChangeColour(this.gameObject);

            //this spike will be an observer
            Enemy spike = new Enemy(this.gameObject, new Blue());
            subject.AddObserver(spike);

            //notify subject
            subject.Notify();
        }

    }
}
