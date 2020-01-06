using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public maneger mng;
    public float  wait;
    public GameObject bullspawnableEntity;
    private bool spawn1 = true;
    public void spawn()
    {
        Instantiate(bullspawnableEntity, transform.position, Quaternion.identity, transform.parent);
    }
    public void Start()
    {
        mng = transform.parent.GetComponentInParent<maneger>();
    }
    private void FixedUpdate()
    {
        if (mng.enemyCount < mng.enemyLimit && spawn1) {
            StartCoroutine(spawnTimer());
            mng.enemyCount++;
            spawn1 = false;
        }
    }
    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        spawn();
        spawn1 = true;
    }
}
