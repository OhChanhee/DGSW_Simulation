using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicOfficerEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return currentStat.intelligence >= 800;
    }
}
