using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public AudioSource source;
    public Rigidbody2D bulet;
    public Animator animato;
    public float speed, explosionRadius = 3;
    public float damage;
    public bool explosive;
    public Sprite bulletSprite, explosiveSprite;
    public SpriteRenderer sprite;
    public Collider2D[] efectedEnemys;
    public LayerMask enemyLAYER;
    public void Start()
    {
        if (tag != "alienProjectile") {
            animato.enabled = false;
            //UnityEditor.AssetDatabase.Refresh();
            if (explosive)
            {
                sprite.sprite = explosiveSprite;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                sprite.sprite = bulletSprite;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (explosive)
        {
            efectedEnemys = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
            /*foreach (Collider2D item in efectedEnemys)
            {
                //RaycastHit2D[] Hit = Physics2D.RaycastAll(transform.position, transform.position - item.transform.position, explosionRadius, 1);

            }*/
            
            //give damage using foreach 
            foreach (Collider2D item in efectedEnemys)
            {
                if (item.gameObject.GetComponent<helth>() != null) {
                    helth hp = item.gameObject.GetComponent<helth>();
                    hp.takeDamage(damage);
                }
            }
            Destroy(gameObject, 1.7f);
            //play sound
            source.Play();
            //play animation
            sprite.sortingOrder = 10;
            animato.enabled = true;
            animato.SetTrigger("explosion");
            //disable unnececary components 
            GetComponent<bullet>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }
        else
        {
            if (collision.gameObject.GetComponent<helth>() != null)
            {
                if (collision.transform.tag == "Player" && transform.tag == "alienProjectile")
                {
                    helth hp = collision.gameObject.GetComponent<helth>();
                    hp.takeDamage(damage);
                }
                if (collision.transform.tag != "Player" && transform.tag != "alienProjectile")
                {
                    helth hp = collision.gameObject.GetComponent<helth>();
                    hp.takeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
