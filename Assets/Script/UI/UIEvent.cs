using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    public GameObject panel;
    public GameObject sound;

    private bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        if(isPause)
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            sound.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            sound.SetActive(false);
        }

        isPause = !isPause;
    }
}
