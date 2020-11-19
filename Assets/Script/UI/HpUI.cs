using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUI : MonoBehaviour
{
    public GameObject player;

    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = player.GetComponent<Player>().hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (hp > player.GetComponent<Player>().hp && hp != 0)
            {
                GameObject nowHp = GameObject.Find("Hp" + hp);
                nowHp.GetComponent<Animator>().SetTrigger("HpDown");

                hp = player.GetComponent<Player>().hp;
            }
        }
    }
}
