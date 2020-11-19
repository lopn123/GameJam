using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    public Slider backVolum;
    public float time;
    [HideInInspector]
    public bool endAni;
    
    private float curTime, backVol;

    // Start is called before the first frame update
    void Start()
    {

        //backVol = PlayerPrefs.GetFloat("backvol", 1f);
        //backVolum.value = backVol;
        //GetComponent<AudioSource>().volume = backVolum.value;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        if (endAni)
        {
            GetComponent<SpriteRenderer>().sprite = null;

            if (curTime >= time)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if(!gameObject.CompareTag("Detect")) transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -2);
        }

        //SoundSlider();
    }

    //public void SoundSlider()
    //{
    //    GetComponent<AudioSource>().volume = backVolum.value;
    //    backVol = backVolum.value;
    //    PlayerPrefs.SetFloat("backvol", backVol);
    //}
}
