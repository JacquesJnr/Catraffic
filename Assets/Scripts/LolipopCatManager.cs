using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolipopCatManager : MonoBehaviour
{

    public GameObject stopCat;
    float currentTime = 0f;
    float redTime = 1.5f;
    float timeReset = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTime += Time.deltaTime;

        if (currentTime > redTime)
        {
            stopCat.SetActive(false);

        }
        else
        {
            stopCat.SetActive(true);
        }

        if (currentTime > timeReset)
        {
            currentTime = 0f;
        }

    }
}
