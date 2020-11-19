using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBall : MonoBehaviour
{

    [SerializeField]
    public GameObject ClearUI;

    Vector3 FirstPos, SecondPos, vMousemove;
    Vector3 pos;

    [SerializeField]
    int Clearheight;

    [SerializeField]
    float maxspeed = 0.15f;
    bool shot = true;

    // Start is called before the first frame update
    void Start()
    {
        ClearUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (shot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FirstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10); //마우스 클릭 포지션
            }

            if (Input.GetMouseButtonUp(0))
            {
                SecondPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10); //마우스를 땠을 때 포지션

                if ((SecondPos - FirstPos).magnitude < 1) return;
                vMousemove = (SecondPos - FirstPos).normalized;  //각도


                vMousemove = new Vector3(vMousemove.y >= 0 ? vMousemove.x : vMousemove.x >= 0 ? 1 : -1, Mathf.Clamp(vMousemove.y, 0.2f, 1), 0); //최소, 최대 각도 조절
                vMousemove = vMousemove.normalized;

                StartCoroutine(Move());
                shot = false;
            }


        }

        Clear();

    }

    private void FixedUpdate()
    {
        pos = this.gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Left" || other.gameObject.tag == "Right") //태그가 Wall 또는 Left, Right 일 때
        {
            vMousemove = Vector3.Reflect(vMousemove, Vector3.up); //반사백터
            vMousemove = vMousemove.normalized;
            vMousemove *= -1; //반전
        }

        if (other.gameObject.tag == "Ceiling" || other.gameObject.tag == "Up")
        {
            vMousemove = Vector3.Reflect(vMousemove, Vector3.right);
            vMousemove = vMousemove.normalized;
            vMousemove *= -1;
        }

        if (other.gameObject.tag == "Down")
        {
            vMousemove = Vector3.Reflect(vMousemove, Vector3.left);
            vMousemove = vMousemove.normalized;
            vMousemove *= -1;
        }

        if (other.gameObject.tag == "Ground") //바닥일 경우
        {
            vMousemove *= 0;
            shot = true;
        }

    }

    IEnumerator Move()
    {
        while (true)
        {
            gameObject.transform.position += vMousemove * maxspeed;

            yield return new WaitForSeconds(1.0f / 120);
            if (shot == true) break;
        }
    }

    void Clear()
    {
        if (pos.y > Clearheight)
        {
            ClearUI.SetActive(true);
            vMousemove *= 0;
        }
    }
}
