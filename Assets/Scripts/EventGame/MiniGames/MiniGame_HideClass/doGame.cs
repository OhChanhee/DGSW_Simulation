using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doGame : MonoBehaviour
{
    energyControl eCtrl;
    public bool isPlus = false;

    void Start()
    {
        eCtrl = GameObject.Find("Canvas").GetComponent<energyControl>();
    }

    void Update()
    {
        doGaming();
    }

    public void doGaming()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("누름누름");
            isPlus = true;
        }
        else
        {
            isPlus = false;
        }
    }
}
