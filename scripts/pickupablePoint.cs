using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupablePoint : MonoBehaviour
{
    public AudioSource source;
    private void OnTriggerEnter2D(Collider2D other)
    {
        void Start()
        {
            StartCoroutine(dest());
        }
        if (other.transform.tag == "Player")
        {
            source.Play();
            other.gameObject.GetComponent<moawment>().mng.canvas.GetComponent<ui>().score += 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StopAllCoroutines();
            Destroy(gameObject, 5);
        }
    }
    IEnumerator dest()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
}
