using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return currentStat.leadership >= 800 && currentStat.creative >= 800;
    }
}
