using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Jacques Visser
// Apr 6th 2021
// Catraffic

/*
 * Catraffic cars have the following properties:

    - A Lane: Which one of the three lanes it moves throughout
    - A Stop,Go & Stunned State: Defines how far and when the car can move at any time
    - Speed: How fast the car should move

    Cars will be instantiated in one of the three rows, there can be up to three cars behind a traffic
    light in a lane at any given moment. 

    Cars can move past the traffic light so long as a light is green and no predestrians block the cars' path.

    Before passing the traffic light, a car will check to see if there are any pedestrians infront of 
    them with a Raycast.

    In the event there is a pedestrian blocking the cars' path, the cars state will automatically be
    set to Stopped, the respective lanes light will turn inactive (RED) and the Lolipop Cat will force the entire lane to stop moving for a set amount of time.
   */

public enum CarDirection
{
    Left,
    Right
}

public class Car : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float rayLength = 4f;
    public CarDirection direction;
    public Vector2 maxTravelDistance;

    private void Awake()
    {
        
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(2.45f, 2.4f), step);
    }

    // Draws a raycast infront of the cars
    public void PedestrianCheck()
    {
        // Send out a ray cast infront of the car
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), rayLength);

        // If the ray hits something
        if (hit.collider != null)
        {
            Debug.Log(gameObject.name + ": hit " + hit.collider.name);            
        }       
        else
        {
            Debug.Log(gameObject.name + ": Ready To Move!");        
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (direction == CarDirection.Left)
            Gizmos.DrawRay(transform.position, Vector2.left * rayLength);
        else
            Gizmos.DrawRay(transform.position, Vector2.right * rayLength);
    }
}
