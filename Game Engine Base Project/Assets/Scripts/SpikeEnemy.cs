using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            EnemyManager.enemyInstance.ChangeColour(this.gameObject);
        }
    }
}
