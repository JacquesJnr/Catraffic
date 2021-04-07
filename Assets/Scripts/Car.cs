using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class Car : MonoBehaviour
{
    [SerializeField] private Transform topSpawn;
    [SerializeField] private Transform midSpawn;
    [SerializeField] private Transform botSpawn;
    [SerializeField] private GameObject carRightPrefab;
    [SerializeField] private GameObject carLeftPrefab;

    public Transform topLane,midLane,botLane;

    public GameObject spawnedCar;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnedCar = Instantiate(carRightPrefab, topSpawn.position, Quaternion.identity, topLane);          
        }

        if(GameObject.Find("car_right(Clone)"))
        {
            // If light is red
            if(spawnedCar.transform.localPosition.x > -5.8f)
            {
                spawnedCar.transform.Translate(Vector2.left * 20 * Time.deltaTime);
            }            

            // The c
            if (spawnedCar.transform.localPosition.x < -18.0f)
            {
                Destroy(spawnedCar);
            }
        }        
    }
}
