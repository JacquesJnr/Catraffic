using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingTimer : MonoBehaviour
{
   [SerializeField] private float timerSpeed = 0.8f;
   [SerializeField] private float elapsed;
    private CarManager carManager;
    
    private void Awake()
    {
        carManager = FindObjectOfType<CarManager>(); 
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timerSpeed){
            elapsed = 0f;

            if (carManager.topCarCount.Count < 3)
                carManager.SpawnTopLane();
            
            if (carManager.middleCarCount.Count < 3)
                carManager.SpawnMidLane();

            if (carManager.bottomCarCount.Count < 3)
                carManager.SpawnBotLane();
        }
    }
}
