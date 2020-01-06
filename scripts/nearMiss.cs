using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearMiss : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("avbbbbb");
        if (collision.transform.tag == "alienProjectile" && transform.parent.tag == "Player")
        {
            maneger mng = GetComponentInParent<moawment>().mng;
            mng.nearMiss += 1;
        }
    }
}
