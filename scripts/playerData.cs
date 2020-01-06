using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    //save data
    public float score = 0, money = 0, musicVolume = 0;
    public string currentGunName;
    //save data
    public static string path = "database";
    public moawment moavm;
    //public GameObject mngOBJ;
    public Item gun1, gun2;
    public void setStartVariebles()
    {
        
    }
    void Start()
    {
    }
    public void LoadGun(string gunName)
    {
        ItemContainer ic = ItemContainer.Load(path);
        foreach (Item item in ic.items)
        {
            if (item.name == gunName)
            {
                
                gun1 = item;
                //Load gun data to moavment
            }
        }
    }
    void Update()
    {
        
    }
    public void savePlayer()
    {
        saveSystem.SavePlayer(this);
    }
    public void loadPlayer()
    {
        saveData data = saveSystem.LoadPlayer();
        score = data.score;
    }
}
