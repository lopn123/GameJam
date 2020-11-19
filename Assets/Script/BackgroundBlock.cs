using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBlock : MonoBehaviour
{
    public GameObject Block1, Block2;
    
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 0)
        {
            Block2.GetComponent<Animator>().SetTrigger("Play");
            Invoke("countUpdate", 0.7f);
        }
        else if(count == 1)
        {
            Block1.GetComponent<Animator>().SetTrigger("Play");
            Block2.GetComponent<Animator>().SetTrigger("Play");
            Invoke("countUpdate", 0.7f);
        }
    }
    private void countUpdate()
    {
        if (count == 0) count++;
        else if (count > 0) count = 0;
    }
}
