using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class maneger : MonoBehaviour
{
    public int mapRows = 100, mapColums = 100;
    public int enemyCount = 0, enemyLimit = 15;
    //[SerializeField]
    public int[,] tiles  = new int[1000, 1000];
    public Tilemap tileMap;
    public GameObject player, canvas, magazine, pointOBJ;
    public float nearMiss, levelBoundariesX1 = -1, levelBoundariesX2 = 20, levelBoundariesY1 = -1, levelBoundariesY2 = 20;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        //player = GetComponentInChildren<GameObject>(tag == "Player");
        //canvas = GameObject.FindGameObjectWithTag("Canvas");
        //canvas.GetComponent<ui>().mngOBJ = gameObject;
        //canvas.GetComponent<ui>().assignGun();
        StartCoroutine(ammoSpawn());
        StartCoroutine(pointSpawn());
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<moawment>().mng = GetComponent<maneger>();
        canvas.GetComponent<ui>().mngOBJ = gameObject;
        player.GetComponent<moawment>().equipGun();
        canvas.GetComponent<ui>().assignGun();
        for (int i = 0; i < 4; i++)
        {
            GameObject mg = Instantiate(pointOBJ);
            randomPos(mg);
            GameObject mg2 = Instantiate(magazine);
            randomPos(mg2);
        }
    }
    private void Update()
    {
        if (nearMiss >= 3)
        {
            nearMiss = 0;
            player.GetComponent<helth>().Helth += 25;
        }
    }
    IEnumerator ammoSpawn()
    {

        yield return new WaitForSeconds(Random.Range(10, 20));
        GameObject mg = Instantiate(magazine);
        randomPos(mg);
        StartCoroutine(ammoSpawn());
    }
    IEnumerator pointSpawn()
    {

        yield return new WaitForSeconds(Random.Range(5, 10));
        GameObject mg = Instantiate(pointOBJ);
        randomPos(mg);
        StartCoroutine(pointSpawn());
    }
    public void randomPos(GameObject targetOBJ) {
        Vector3 pos = new Vector3(Random.Range(levelBoundariesX1, levelBoundariesX2), Random.Range(levelBoundariesY1, levelBoundariesY2), 6f);

        if (Physics2D.OverlapBox(new Vector2(pos.x, pos.y), new Vector2(0.5f, 0.5f), 0f))
        {
            randomPos(targetOBJ);
            return;
        }

        targetOBJ.transform.position = pos;
    }
}
