using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //singleton
    public static EnemyManager enemyInstance;
    

    void Awake()
    {
        //make this an instance if it doesn't exist
        if (!enemyInstance)
        {
            enemyInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColour(GameObject enemy1) //change the appearance of enemy
    {
        enemy1.GetComponent<Renderer>().materials[0].color = Color.red;
    }
}
