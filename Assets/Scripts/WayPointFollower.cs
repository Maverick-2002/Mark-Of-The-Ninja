 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoint;
    private int currentwaypointindex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoint[currentwaypointindex].transform.position,transform.position) < .1f)
        {
            currentwaypointindex++;
            if (currentwaypointindex >= waypoint.Length) 
            { 
                currentwaypointindex = 0; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentwaypointindex].transform.position, Time.deltaTime * speed);
    }
}
