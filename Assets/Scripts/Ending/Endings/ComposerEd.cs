using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposerEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return (currentStat.music >= 800 && currentStat.sensibility >= 800);
    }
}
