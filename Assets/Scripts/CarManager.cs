using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private Transform topSpawn;
    [SerializeField] private Transform midSpawn;
    [SerializeField] private Transform botSpawn;
    [SerializeField] private GameObject topPrefab;
    [SerializeField] private GameObject middlePrefab;
    [SerializeField] private GameObject bottomPrefab;

    public Transform topLane, midLane, botLane;

    [SerializeField] public List<GameObject> topCarCount;
    [SerializeField] public List<GameObject> middleCarCount;
    [SerializeField] public List<GameObject> bottomCarCount;

    private Car car;

    //Jake's sound stuff
    public GameObject camera;
    public AudioClip honkTop;
    public AudioClip honkMid;
    public AudioClip honkBot;
    AudioSource cameraSound;
    //Jake's sound stuff

    private void Awake()
    {
        car = FindObjectOfType<Car>();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Top")) 
            topCarCount.Add(go);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mid"))
            middleCarCount.Add(go);

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bottom"))
            bottomCarCount.Add(go);

        //Jake's sound stuff
        cameraSound = camera.GetComponent<AudioSource>();
        //Jake's sound stuff

    }

    private void Update()
    {
        for(int i = 0; i < topCarCount.Count; i++)
        {
            topCarCount[i].name = "Top_" + (i+1).ToString();

            // Check if car is past the ped crossing
            if (topCarCount[i].transform.localPosition.x < -9.6f)
                topCarCount.RemoveAt(i);
        }

        for (int i = 0; i < middleCarCount.Count; i++)
        {
            middleCarCount[i].name = "Middle_" + (i+1).ToString();

            if (middleCarCount[i].transform.localPosition.x > 9.6f)
                middleCarCount.RemoveAt(i);
        }

        for (int i = 0; i < bottomCarCount.Count; i++)
        {
            bottomCarCount[i].name = "Bottom_" + (i+1).ToString();

            if (bottomCarCount[i].transform.localPosition.x < -9.6f)
                bottomCarCount.RemoveAt(i);
        }

    }

    public void SpawnTopLane()
    {

        //Jake's audio stuff
        cameraSound.PlayOneShot(honkTop, 1f);
        //Jake's audio stuff

        GameObject go;
        go = Instantiate(topPrefab, topSpawn.position, Quaternion.identity, topLane);

        topCarCount.Add(go);
    }

    public void SpawnMidLane()
    {

        //Jake's audio stuff
        cameraSound.PlayOneShot(honkMid, 1f);
        //Jake's audio stuff

        GameObject go;
        go = Instantiate(middlePrefab, midSpawn.position, Quaternion.identity, midLane);

        middleCarCount.Add(go);
    }
    public void SpawnBotLane()
    {

        //Jake's audio stuff
        cameraSound.PlayOneShot(honkBot, 1f);
        //Jake's audio stuff

        GameObject go;
        go = Instantiate(bottomPrefab, botSpawn.position, Quaternion.identity, botLane);

        bottomCarCount.Add(go);
    }
}
