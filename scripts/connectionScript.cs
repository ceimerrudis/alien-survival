using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectionScript : MonoBehaviour
{
    public GameObject canvas, manegerOBJ, player;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //manegerOBJ = GameObject.FindGameObjectWithTag("maneger");
        //player = GameObject.FindGameObjectWithTag("Player");
        //manegerOBJ.GetComponent<maneger>().canvas = canvas;
        
    }
}
