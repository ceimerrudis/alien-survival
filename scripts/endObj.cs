using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endObj : MonoBehaviour
{
    public maneger mng;
    private bool space;
    private void Start()
    {
        mng = GameObject.FindGameObjectWithTag("maneger").GetComponent<maneger>() ;
    }
    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            space = true;
        }
        else
        {
            space = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (space && collision.tag == "Player")
        {
            if (Random.Range(1, 3) == 1) {
                //play add
            }
            mng.canvas.GetComponent<ui>().actualScore = mng.canvas.GetComponent<ui>().score;
            mng.canvas.GetComponent<ui>().Menu();
        }
    }
}
