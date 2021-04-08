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

    [SerializeField] public List<GameObject> topCars;
    [SerializeField] public List<GameObject> middleCars;
    [SerializeField] public List<GameObject> bottomCars;

    private void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Top")) 
        {
            topCars.Add(go);
            go.name = "Top_" + topCars.IndexOf(go).ToString();
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Middle"))
        {
            topCars.Add(go);
            go.name = "Middle_" + topCars.IndexOf(go).ToString();
        }

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bottom"))
        {
            topCars.Add(go);
            go.name = "Bottom_" + topCars.IndexOf(go).ToString();
        }
    }

    private void Update()
    {
        for(int i = 0; i < topCars.Count; i++)
        {
            if(topCars[i].transform.localPosition.x < -20f)
            {
                Destroy(topCars[i]); 
                topCars.RemoveAt(i);
            }
        }
    }
}
