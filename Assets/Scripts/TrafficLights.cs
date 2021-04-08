using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Jacques Visser
// Apr 6th 2021
// Catrafficx

/*
    Each lane has a traffic light that can switched on or off to control the flow of traffic in that respective lane,    
    When a light is active (GREEN) the car in at the front of the queue's state will be set to move. 

    A traffic light's state is controlled by the player:
    - Pressing the key once will set the traffic lights state to ACTIVE/ GREEN
    - Re-pressing the key will set the traffic lights state to INACTIVE/ RED

    The lights states are not exclusively controlled by the players inputs, the light can be set to inactive (RED) if the car at the front of the queue,
    does not pass a pedestrian check at the time the player would have moved them.

    If the car in the front of its lanes' queue were to hit a pedestrian, the light will automatically be set to the inactive state (RED).
*/

public class TrafficLights : MonoBehaviour
{
    [SerializeField] private SpriteRenderer topLaneRenderer;
    [SerializeField] private SpriteRenderer midLaneRenderer;
    [SerializeField] private SpriteRenderer botLaneRenderer;

    private Sprite greenLight;
    private Sprite redLight;
    private Sprite noLight;

    private KeyCode topKey;
    private KeyCode midKey;
    private KeyCode botKey;


    [SerializeField] UnityEvent OnGreen;

    private void Awake()
    {
        greenLight = Resources.Load<Sprite>("Art/Green1");
        redLight = Resources.Load<Sprite>("Art/Red1");
        noLight = Resources.Load<Sprite>("Art/Blank");
    }

    private void Start()
    {
        topKey = KeyCode.Alpha1;
        midKey = KeyCode.Alpha2;
        botKey = KeyCode.Alpha3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(topKey))
        {
            SetLightState(topLaneRenderer);
        }

        if (Input.GetKeyDown(midKey))
        {
            SetLightState(midLaneRenderer);
        }

        if (Input.GetKeyDown(botKey))
        {
            SetLightState(botLaneRenderer);
        }

        
    }

    public void SetLightState(SpriteRenderer renderer)
    {
        if(renderer.sprite != greenLight)
        {
            renderer.sprite = greenLight;
            OnGreen.Invoke();
        }
            
        else
            renderer.sprite = redLight;
    }
}
