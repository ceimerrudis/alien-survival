using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;


public class moawment : MonoBehaviour//NetworkBehaviour
{
    [HideInInspector]
    public Item currentGun, secondaryGun;
    public AudioClip shootAudio, emptyAudio;
    public AudioSource source;
    private float timer = 0, turnSpeed = 15f;
    public float fireRate = 1;
    public float speed, w = 0, buletSpeed = 100;
    public float jumpPower = 10f, doubleJumpPower = 50f, jump = 0, pullSpeed = 15, ammo = 30f;
    private float  x = 0, feetSize = 0.2f;
    private bool mouse1 = false, hasRoped = false, grounded = false;
    public LayerMask enemys, ground;
    public Animator animator;
    private Vector2 mowement;
    public Camera cam;
    private Vector2 cursor, recoilDIR, laserPointer;
    public Rigidbody2D player;
    private bool firstEntry = true, laserIshoot = false, doubleJumped = false, doubleClick = false, ChargeReloaded = true, mouse0;
    private float lastClickTime, clickTime;
    public gun playerGun;
    [HideInInspector]
    public maneger mng;
    [SerializeField]
    private GameObject firePoint, Graphic;
    [SerializeField]
    private camera came;
    void Start()
    {
       
    }
    public void equipGun()
    {
        if (mng.canvas.GetComponent<playerData>().gun1 != null)
        {
            currentGun = mng.canvas.GetComponent<playerData>().gun1;
        }
    }
    void Update()
    {
        if(firstEntry){
            firstEntry = false;
            came = GetComponentInChildren<camera>();
            mng = transform.parent.GetComponentInParent<maneger>();
            playerGun = GetComponent<gun>();
            mng.player = gameObject;
            mng.canvas.GetComponent<ui>().ammo = ammo;
        }
        if (currentGun.autoFire)
        {
            if (Input.GetMouseButton(0))
            {
                mouse0 = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouse0 = true;
            }
        }
        if (Input.GetMouseButton(1))
        {
            mouse1 = true;
        }
        mowement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        cursor = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (mowement.x != 0 || mowement.y != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
    void FixedUpdate() {
        float angle = Mathf.Atan2(cursor.y, cursor.x) * Mathf.Rad2Deg - 90;
        Quaternion lookDr = Quaternion.AngleAxis(angle, Vector3.forward);
        Graphic.transform.rotation = Quaternion.Slerp(Graphic.transform.rotation, lookDr, turnSpeed * Time.fixedDeltaTime);
        player.velocity += mowement * speed * Time.fixedDeltaTime;
        if (mouse0)
        {
            if (Time.time - timer >= currentGun.fireRate && ammo > 0f)
            {
                source.clip = shootAudio;
                source.Play();
                ammo--;
                mng.canvas.GetComponent<ui>().ammo = ammo;
                playerGun.Cmdshoot(currentGun.damage, buletSpeed, currentGun.explosive);
                timer = Time.time;
            }
            else if(ammo <= 0)
            {
                source.clip = emptyAudio;
                source.Play();
            }
        }
        mouse0 = false;
        mouse1 = false;
    }
}
