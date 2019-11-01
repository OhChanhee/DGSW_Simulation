using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SummerVacation : MonoBehaviour
{
    CharacterStat changement = CharacterStat.zero;

    // Start is called before the first frame update
    void Start()
    {
        InitChangement();

        ChangeStat();
    }

    void InitChangement()
    {
        changement.fatigue = -40;
    }

    void ChangeStat()
    {
        CharacterManager.Get_instance().characterStat += changement;

        DateTime curTime = CharacterManager.Get_instance().curdate.dateTime;

        CharacterManager.Get_instance().curdate.dateTime = new DateTime(curTime.Year, curTime.Month == 12 ? 1 : curTime.Month + 1, curTime.Day);

        if (CharacterManager.Get_instance().grade == 3) SceneManager.LoadScene("Ending");
    }
}
