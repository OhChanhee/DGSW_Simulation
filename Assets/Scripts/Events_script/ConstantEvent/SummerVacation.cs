using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CharacterManager.Get_instance().curdate.dateTime.AddMonths(1);

        if (CharacterManager.Get_instance().grade == 3) SceneManager.LoadScene("Ending");
    }
}
