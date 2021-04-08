﻿using System.Collections;
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

    [SerializeField] private BoxCollider2D trafficBlockerTop;
    [SerializeField] private BoxCollider2D trafficBlockerMid;
    [SerializeField] private BoxCollider2D trafficBlockerBot;

    private Sprite greenLight;
    private Sprite redLight;
    private Sprite noLight;

    private KeyCode topKey;
    private KeyCode midKey;
    private KeyCode botKey;

    [SerializeField] public UnityEvent onGreen;
    [SerializeField] public UnityEvent onRed;

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
        if (Input.GetKeyDown(topKey) || Input.GetKeyDown("[1]"))
        {
            SetLightState(1);
        }

        if (Input.GetKeyDown(midKey) || Input.GetKeyDown("[2]"))
        {
            SetLightState(2);
        }

        if (Input.GetKeyDown(botKey) || Input.GetKeyDown("[3]"))
        {
            SetLightState(3);
        }        
    }

    public void SetLightState(int trafficLight)
    {
        SpriteRenderer renderer = null;
        BoxCollider2D blocker = null;
        
        switch (trafficLight)
        {
            case 1:
                renderer = topLaneRenderer;
                blocker = trafficBlockerTop;
                break;
            case 2:
                renderer = midLaneRenderer;
                blocker = trafficBlockerMid;
                break;
            case 3:
                renderer = botLaneRenderer;
                blocker = trafficBlockerBot;
                break;
        }

        if(renderer.sprite != greenLight)
        {
            renderer.sprite = greenLight;
            blocker.enabled = false;
        }

        else 
        {
            renderer.sprite = redLight;
            blocker.enabled = true;
        }
    }
}
