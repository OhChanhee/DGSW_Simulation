using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        CharacterManager.Get_instance().curdate.dateTime.AddMonths(1);
    }
}
