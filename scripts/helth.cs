using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helth : MonoBehaviour
{
    public float Helth;
    public maneger mng;
    public AudioSource source;
    public AudioClip deth, hurt;
    private void Start()
    {
        mng = transform.parent.GetComponentInParent<maneger>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            mng.canvas.GetComponent<ui>().helthc = Helth;
        }
        if (Helth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                //mng.canvas.GetComponent<ui>().StopCoroutine(gameTime());
                source.Play();
                mng.canvas.GetComponent<ui>().Menu();
            }
            else {
                source.Play();
                //mng.canvas.GetComponent<ui>().score += 1;
                mng.enemyCount--;
                gameObject.GetComponent<enemy>().enabled = false;
                gameObject.GetComponent<enmyShoot>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<helth>().enabled = false;
                Destroy(gameObject, 5);
            }
        }
    }
    public void takeDamage(float damage)
    {
        Helth -= damage;
        if (gameObject.tag == "Player")
        {
            if (Helth <= 0)
            {
                source.clip = deth;
            }
            else
            {
                source.clip = hurt;
            }
            source.Play();
        }

    }
}
