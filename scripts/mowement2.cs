using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mowement2 : MonoBehaviour
{

    private float timer = 0, turnSpeed = 15f;
    public float fireRate = 1/*, speedPullX = 10, speedPullY = 1*/;
    public float speed, w = 0, buletSpeed = 1000;
    public float jumpPower = 10f, doubleJumpPower = 50f, jump = 0, pullSpeed = 15;
    //public float turnSpeed = 10f;
    private float x = 0, feetSize = 0.2f;
    private bool mouse1 = false, hasRoped = false, grounded = false;
    public LayerMask enemys, ground;
    public Animator animator;
    private Vector2 mowement;
    public Camera cam;
    private Vector2 cursor, recoilDIR, laserPointer;
    public Rigidbody2D player;
    private bool laserIshoot = false, doubleJumped = false, doubleClick = false, ChargeReloaded = true, mouse0;
    private float lastClickTime, clickTime;
    private gun playerGun;
    private maneger mng;
    [SerializeField]
    private GameObject firePoint, Graphic;

    // Start is called before the first frame update
    void Start()
    {
        mng = transform.parent.GetComponentInParent<maneger>();
        playerGun = GetComponentInParent<gun>();
        mng.player = transform.parent.gameObject;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouse0 = true;
        }
        if (Input.GetMouseButton(1))
        {
            mouse1 = true;
        }
        if (Input.GetKeyDown("r"))
        {
            player.transform.position = new Vector3(0f, 0f, -17f);
            player.velocity = new Vector2(0f, 0f);
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

    void FixedUpdate()
    {


        float angle = Mathf.Atan2(cursor.y, cursor.x) * Mathf.Rad2Deg - 90;
        Quaternion lookDr = Quaternion.AngleAxis(angle, Vector3.forward);
        Graphic.transform.rotation = Quaternion.Slerp(transform.rotation, lookDr, turnSpeed * Time.fixedDeltaTime);
        player.velocity += mowement * speed * Time.fixedDeltaTime;
        if (mouse0)
        {
            if (Time.time - timer >= fireRate)
            {
                //playerGun.shoot(10, buletSpeed);
                timer = Time.time;
            }
        }
        mouse0 = false;
        mouse1 = false;
    }
}

