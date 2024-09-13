using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB; 
    public float speed = 5f;

    private bool movingToB = true;

    void Update()
    {
       
        Vector3 target = movingToB ? pointB : pointA;

        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            
            movingToB = !movingToB;
        }
    }
}
