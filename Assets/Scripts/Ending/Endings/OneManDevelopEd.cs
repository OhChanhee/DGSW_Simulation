using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManDevelopEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return currentStat.creative >= 800;
    }
}
