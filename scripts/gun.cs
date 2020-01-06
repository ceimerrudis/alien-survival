using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class gun : MonoBehaviour//NetworkBehavioure
{
    public GameObject bullet, FirePoint, sprite;
    //[Command]
    public void Cmdshoot(float damage, float speed, bool explosive) {
        //sound
        GameObject bulet = Instantiate(bullet, FirePoint.transform.position, sprite.transform.rotation);
        Rigidbody2D rb = bulet.GetComponent<Rigidbody2D>();
        bulet.transform.position += new Vector3(0f, 0f, 2f);
        rb.AddForce(FirePoint.transform.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        bulet.GetComponent<bullet>().explosive = explosive;
        bulet.GetComponent<bullet>().damage = damage;
        //Debug.Log(explosive);
        //NetworkServer.SpawnWithClientAuthority(bulet, connectionToClient);
        Destroy(bulet, 15f);
 
    }
}
