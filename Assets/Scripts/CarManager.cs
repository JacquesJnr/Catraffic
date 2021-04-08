using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private Transform topSpawn;
    [SerializeField] private Transform midSpawn;
    [SerializeField] private Transform botSpawn;
    [SerializeField] private GameObject carRightPrefab;
    [SerializeField] private GameObject carLeftPrefab;

    public Transform topLane, midLane, botLane;

    [SerializeField] List<GameObject> carsInTopLane;

    private void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Top")) 
        {
            carsInTopLane.Add(go);
            go.name = "Top_" + carsInTopLane.IndexOf(go).ToString();
        }
            
    }
}
