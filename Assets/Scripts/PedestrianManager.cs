using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : MonoBehaviour
{
    [SerializeField] private GameObject topPrefab;
    [SerializeField] private GameObject botPrefab;

    [SerializeField] List<GameObject> topPedestrians;
    [SerializeField] List<GameObject> bottomPedestrians;

    public Transform topSpawn;
    public Transform botSpawn;
    public Transform topParent;
    public Transform botParent;

    [SerializeField] private float timerSpeed = 3f;
    [SerializeField] private float elapsed;

    void Start()
    {
        
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= timerSpeed)
        {
            elapsed = 0f;

            //SpawnBottomPedestrians();
            SpawnTopPedestrians();
        }

        for (int t = 0; t < topPedestrians.Count; t++)
        {
            topPedestrians[t].name = "Downwards_" + (t + 1).ToString();

            if (transform.position.y <= -6f) 
            {
                Destroy(topPedestrians[t]);
            }
        }

        for (int b = 0; b < bottomPedestrians.Count; b++)
        {
            bottomPedestrians[b].name = "Upwards_" + (b + 1).ToString();

            if (transform.position.y >= 6f)
            {
                Destroy(bottomPedestrians[b]);
            }
        }
    }

    public void SpawnTopPedestrians()
    {
        GameObject go = null;

        go = Instantiate(topPrefab, topSpawn.position, Quaternion.identity, topParent);
        topPedestrians.Add(go);
    }

    public void SpawnBottomPedestrians()
    {
        GameObject go = null;

        go = Instantiate(botPrefab, botSpawn.position, Quaternion.identity, botParent);
        bottomPedestrians.Add(go);
    }
}
