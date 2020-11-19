using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public static int hitCount; //공이 블럭에 부딪힌 횟수
    public static bool detectOn = true;

    private float curTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!detectOn)
        {
            if(curTime >= 15f)
            {
                curTime = 0;
                detectOn = true;
            }
            else
            {
                curTime += Time.deltaTime;
            }
        }
    }
}
