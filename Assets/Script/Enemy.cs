using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Normal,         //일반
    Effect,         //이펙트
    Detect          //탐지 능력 비활성화
}

public class Enemy : MonoBehaviour
{
    public BlockType type;
    [Space(10f)]
    public int hp = 1;
    [Space(5f)]
    public GameObject effect;
    [Space(10f)]
    public Sprite image;
    public Material mat;
    public GameObject detect;

    private Sprite sImg;
    private Material sMat;
    private Animator anim;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        sImg = gameObject.GetComponent<SpriteRenderer>().sprite;
        sMat = gameObject.GetComponent<SpriteRenderer>().material;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LightOn();

        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            switch (type) //블럭 종류
            {
                case BlockType.Effect:
                    Instantiate(effect, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -2), Quaternion.identity);
                    break;

                case BlockType.Detect:
                    Instantiate(effect, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -2), Quaternion.identity);

                    GameManager.hitCount = 0;
                    GameManager.detectOn = false;

                    break;
            }

            if (type != BlockType.Normal)
            {
                collision.gameObject.GetComponent<Player>().hp--;
            }
            if(GameManager.detectOn && hp < 10)
            {
                GameManager.hitCount++;
            }

            hp--;
        }
    }

    void LightOn()
    {
        if (type != BlockType.Normal && GameManager.hitCount == 5 && count == 0)
        {
            count++;

            Instantiate(detect, new Vector3(this.transform.position.x, this.transform.position.y, -2), Quaternion.identity);
            anim.SetTrigger("LightOn");
            GetComponent<SpriteRenderer>().sprite = image;
            GetComponent<SpriteRenderer>().material = mat;

            Invoke("LightOff", 1f);
        }
    }
    void LightOff()
    {
        GetComponent<SpriteRenderer>().sprite = sImg;
        GetComponent<SpriteRenderer>().material = sMat;

        GameManager.hitCount = 0;
        count = 0;
    }
}
