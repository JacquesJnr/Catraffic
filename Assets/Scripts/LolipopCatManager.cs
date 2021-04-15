using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolipopCatManager : MonoBehaviour
{

    public Sprite stopCat;
    public Sprite startCat;
    public SpriteRenderer lolipopCat;

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
            lolipopCat.sprite = stopCat;
        }
        else
        {
            lolipopCat.sprite = startCat;
        }

        if (currentTime > timeReset)
        {
            currentTime = 0f;
        }

    }
}
