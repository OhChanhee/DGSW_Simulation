using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpringVacation : MonoBehaviour
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
        changement.fatigue = -10;
    }

    void ChangeStat()
    {
        CharacterManager.Get_instance().characterStat += changement;

        DateTime curTime = CharacterManager.Get_instance().curdate.dateTime;

        CharacterManager.Get_instance().curdate.dateTime = new DateTime(curTime.Year, curTime.Month == 12 ? 1 : curTime.Month + 1, curTime.Day);
    }
}
