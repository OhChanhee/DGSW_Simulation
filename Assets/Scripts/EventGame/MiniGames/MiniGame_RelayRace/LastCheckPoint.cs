using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastCheckPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            Debug.Log("Win");
            //스탯 상승
            //SceneManager.LoadScene("Main");
        }
    }
}
