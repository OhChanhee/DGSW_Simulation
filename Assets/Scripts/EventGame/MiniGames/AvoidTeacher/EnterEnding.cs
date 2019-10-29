using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterEnding : MonoBehaviour
{
    public bool isEnter = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            isEnter = true;
        }
    }
}
