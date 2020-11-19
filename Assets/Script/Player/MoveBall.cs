using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    [SerializeField]
    private float startspeed = 4;

    [SerializeField]
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        float randomX, randomY;
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);

        Vector2 vector = new Vector2(randomX, randomY);
        vector = vector.normalized;

        rigid.AddForce(vector * startspeed);
    }
}
