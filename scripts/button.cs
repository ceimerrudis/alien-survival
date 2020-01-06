using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public string gunsName;
    [SerializeField]
    private GameObject canv;
    public void OnEnable()
    {
        
    }
    public void onPress()
    {
        if (canv == null)
        {
            canv = GameObject.FindGameObjectWithTag("Canvas");
        }
        canv.GetComponent<playerData>().LoadGun(gunsName);
        //canv.GetComponent<ui>().mngOBJ.GetComponent<maneger>().player.GetComponent<moawment>().equipGun();
    }
}
