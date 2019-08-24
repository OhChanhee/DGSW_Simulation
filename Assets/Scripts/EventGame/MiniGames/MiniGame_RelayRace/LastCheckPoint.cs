using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastCheckPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            PlayerPrefs.SetString("MinigameResult", "Success");

            SceneManager.LoadScene("Result");
        }
    }
}
