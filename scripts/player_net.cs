using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player_net : NetworkBehaviour
{
    public GameObject player, manegerObj;
    //[SerializeField]
    //private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 0, -6);
    }

    // Update is called once per frame
    void Update()
    {
        manegerObj = GameObject.FindGameObjectWithTag("maneger");
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown("q")) {
            //camera cam2 = cam.GetComponent<camera>();
            //cam2.enabled = false;
            CmdspawnPlayer();
        }
        if (Input.GetKeyDown("e"))
        {
            transform.Translate(0, 0, -6);
        }
        if (Input.GetKeyDown("t"))
        {
            transform.Translate(1, 0, -6);
        }
    }

    [Command]
    void CmdspawnPlayer() {
        GameObject go = Instantiate(player, manegerObj.transform);
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
