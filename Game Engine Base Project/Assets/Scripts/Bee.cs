using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float leftLimit = -10.0f;
    public float rightLimit = 10.0f;
    public float speed = 1;
    private int dir = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightLimit)
        {
            dir = -1;
        }
        else if (transform.position.x < leftLimit)

        {
            dir = 1;
        }
        transform.position += new Vector3 (dir * speed * Time.deltaTime, 0f, 0f);
    }
}
