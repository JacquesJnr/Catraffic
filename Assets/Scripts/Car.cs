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

public enum Lane
{
    Top,
    Middle,
    Bottom
}

public class Car : MonoBehaviour
{
    public CarDirection direction;
    public Lane lane;
    public float force = 2f;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        float step = force * Time.deltaTime;
        
        // Move the car
        switch (direction)
        {
            case CarDirection.Left:
                rb.AddForce(Vector2.left * step);
                break;
            case CarDirection.Right:
                rb.AddForce(Vector2.right * step);
                break;
        }

        if(lane == Lane.Top || lane == Lane.Bottom)
        {
            if (transform.localPosition.x < -20f)
                Destroy(gameObject);
        }
        
        if(lane == Lane.Middle)
        {
            if (transform.localPosition.x > 20f)
                Destroy(gameObject);
        }
    }
}
