using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmyShoot : MonoBehaviour
{
    public SpriteRenderer spriteRen;
    public AudioSource source;
    public float damage, speed, wait;
    public GameObject bullet, FirePoint, sprite;
    private bool shot = false, shot2 = false;
    public Renderer render;
    public void shoot(float damage, float speed)
    {
        if (render.isVisible) {
            source.Play();
        }
        GameObject bulet = Instantiate(bullet, FirePoint.transform.position, sprite.transform.rotation, transform.parent);
        Rigidbody2D rb = bulet.GetComponent<Rigidbody2D>();
        bulet.transform.position += new Vector3(0f, 0f, 2f);
        rb.AddForce(FirePoint.transform.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        Destroy(bulet, 15f);
    }
    public void Start()
    {
        StartCoroutine(shootTimer());
    }
    IEnumerator shootTimer()
    {
        spriteRen.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        spriteRen.color = Color.white;
        yield return new WaitForSeconds(wait - 0.1f);
        shoot(damage, speed);
        StartCoroutine(shootTimer());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
