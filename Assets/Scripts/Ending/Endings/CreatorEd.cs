using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return currentStat.charm >= 800 && currentStat.creative >= 800;
    }
}
