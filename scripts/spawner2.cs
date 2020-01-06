using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public maneger mng;
    public float wait;
    public GameObject bullspawnableEntity;
    private bool spawn1 = true;
    public void spawn(GameObject targetOBJ)
    {
        Vector3 pos = new Vector3(Random.Range(mng.levelBoundariesX1, mng.levelBoundariesX2), Random.Range(mng.levelBoundariesY1, mng.levelBoundariesY2), 6f);

        if (Physics2D.OverlapBox(new Vector2(pos.x, pos.y), new Vector2(0.6f, 0.6f), 0f))
        {
            spawn(targetOBJ);
            return;
        }

        targetOBJ.transform.position = pos;
        
    }
    public void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject targetOBJ = Instantiate(bullspawnableEntity, transform.position, Quaternion.identity, transform);
            Vector3 pos = new Vector3(Random.Range(mng.levelBoundariesX1, mng.levelBoundariesX2), Random.Range(mng.levelBoundariesY1, mng.levelBoundariesY2), 6f);

            if (Physics2D.OverlapBox(new Vector2(pos.x, pos.y), new Vector2(0.6f, 0.6f), 0f))
            { 
                return;
            }

            targetOBJ.transform.position = pos;
        }
        mng = GetComponent<maneger>();
    }
    private void FixedUpdate()
    {
        if (mng.enemyCount < mng.enemyLimit && spawn1)
        {
            StartCoroutine(spawnTimer());
            mng.enemyCount++;
            spawn1 = false;
        }
    }
    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(1);
        GameObject target = Instantiate(bullspawnableEntity, transform.position, Quaternion.identity, transform);
        spawn(target);
        spawn1 = true;
    }
}
