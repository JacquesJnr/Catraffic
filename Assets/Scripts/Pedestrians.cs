using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{
    public float walkSpeed = 2.5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        float step = walkSpeed * Time.deltaTime;

        if(gameObject.tag == "PedTop")
        {
            transform.position = Vector2.MoveTowards(transform.position ,new Vector2(0f, -6f), step);
        }

        if (gameObject.tag == "PedBot")
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-0.5f, 6f), step);
        }
    }

}
