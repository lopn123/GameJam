using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFont : MonoBehaviour
{
    public Sprite spr;
    private Sprite sSpr;

    // Start is called before the first frame update
    void Start()
    {
        sSpr = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeImage()
    {
        GetComponent<SpriteRenderer>().sprite = spr;
    }
    public void ChangeImageInit()
    {
        GetComponent<SpriteRenderer>().sprite = sSpr;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("InGame");
    }
}
