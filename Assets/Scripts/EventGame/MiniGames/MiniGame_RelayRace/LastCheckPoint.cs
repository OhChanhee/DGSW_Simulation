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

            StatSave holder = FindObjectOfType<StatSave>();

            holder.oldStat = CharacterManager.Get_instance().characterStat.clone;
            DontDestroyOnLoad(holder);

            CharacterManager.Get_instance().characterStat.exercise += 300;

            SceneManager.LoadScene("Result");
        }
    }
}
