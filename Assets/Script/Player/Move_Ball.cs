using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Ball : MonoBehaviour
{

    #region 태그
    void Update()
    {
        Angle();
    }

    private void FixedUpdate()
    {
        if(P_Ball.gameObject != null)
        b_pos = P_Ball.transform.position;
    }

    void Start()
    {
        if (CompareTag("Ball")) Start_BALL();
        Line.SetActive(false);
    }


    #endregion

    #region GameManager.Cs
    [Header("GameManagerValue")]
    public float groundY = -30f;
    public object MouseL;
    public Vector3 veryFirstPos;
    public GameObject Arrow, P_Ball;
    public GameObject Line, ClearUI;
    public Quaternion QI = Quaternion.identity;
    public bool shotTrigger;
    public int Clearheight;

    Vector3 FirstPos, SecondPos, gap, b_pos;
    int timerCount;
    bool isMouse, timerStart;
    float timeDelay;
    // Start is called before the first frame update


    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D col) { if (CompareTag("Ball")) StartCoroutine(OnCollisionEnter2D_BALL(col)); }
    public void VeryFirstPosSet(Vector3 pos) { if (veryFirstPos == Vector3.zero) veryFirstPos = pos; }

    void Angle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            b_pos = P_Ball.transform.position;
            FirstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        }

        bool isMouse = Input.GetMouseButton(0);
        if (isMouse)
        {
            //차이값
            SecondPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            if ((SecondPos - FirstPos).magnitude < 1) return;
            gap = (SecondPos - FirstPos).normalized;
            gap = new Vector3(gap.y >= 0 ? gap.x : gap.x >= 0 ? 1 : -1, Mathf.Clamp(gap.y, 0.2f, 1), 0);

            Arrow.transform.position = new Vector3(b_pos.x, -4.55f, -10);
            Arrow.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(gap.y, gap.x) * Mathf.Rad2Deg - 90);


            RaycastHit2D hit = Physics2D.Raycast(veryFirstPos, gap, 10000, 1 << LayerMask.NameToLayer("Wall"));

            //라인
            Line.SetActive(true);
        }
        Arrow.SetActive(isMouse);

        if (Input.GetMouseButtonUp(0))
        {
            //초기화
            timerStart = true;
            veryFirstPos = Vector3.zero;
            FirstPos = Vector3.zero;

            Line.SetActive(false);

        }
    }

    #endregion

    #region BallScript.cs
    [Header("BallScriptValue")]
    public Rigidbody2D rigid;
    public bool isMoving;

    Move_Ball GM;
    void Start_BALL() => GM = GameObject.FindWithTag("GameManager").GetComponent<Move_Ball>();

    IEnumerator OnCollisionEnter2D_BALL(Collision2D col)
    {
        yield return null;
        GameObject Col = col.gameObject;

        if (Col.CompareTag("Ground"))
        {
            GM.VeryFirstPosSet(transform.position);
        }
    }


    #endregion

}
