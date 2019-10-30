using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerCamp : MonoBehaviour
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
        changement.sociability = 50;
        changement.fatigue = 10;
        changement.hp = 10;
    }

    void ChangeStat()
    {
        CharacterManager.Get_instance().characterStat += changement;
    }
}
