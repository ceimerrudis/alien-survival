using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class camera :NetworkBehaviour
{
    [SerializeField]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void auth() {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position + new Vector3(0f, 0f, -11f);
    }
}
