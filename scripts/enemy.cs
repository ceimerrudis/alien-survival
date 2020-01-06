using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private maneger mng;
    private Transform player;
    public float moveSpeed, turnSpeed, xx, yy, anglesMult, ofset = 90;
    private Rigidbody2D thisEnemyRB;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(0f, 0f, 2f);
        mng = GetComponentInParent<maneger>();
        player = mng.player.transform;
        thisEnemyRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {





        xx = (player.position - transform.position).x;
        yy = (player.position - transform.position).y;
        float angle = Mathf.Atan2(yy, xx) * Mathf.Rad2Deg - 90f;
        Quaternion lookDr = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDr, turnSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, player.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //   runnnn!
            //transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }




    }
}











/*
        xx = (player.position - transform.position).x;
        yy = (player.position - transform.position).y;
        float angle = Mathf.Atan2(yy, xx) * Mathf.Rad2Deg - 90f;
        Quaternion lookDr = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDr, turnSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(transform.position, player.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else {
            //   runnnn!
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }*/
