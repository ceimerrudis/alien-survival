using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(dest());
    }
    public AudioSource source;
    public float ammoAmount = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player") {
            source.Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<ammo>().enabled = false;
            other.gameObject.GetComponent<moawment>().ammo += ammoAmount;
            other.gameObject.GetComponent<moawment>().mng.canvas.GetComponent<ui>().ammo = other.gameObject.GetComponent<moawment>().ammo;
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
