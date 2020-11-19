using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainDetect : MonoBehaviour
{
    public GameObject[] remainDetect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.hitCount == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                remainDetect[i].SetActive(false);
            }
        }
        else if (GameManager.hitCount > 0 && GameManager.hitCount <= 5)
        {
            for (int i = 0; i < GameManager.hitCount; i++)
            {
                if (!remainDetect[i].activeInHierarchy) remainDetect[i].SetActive(true);
            }
        }
    }
}
