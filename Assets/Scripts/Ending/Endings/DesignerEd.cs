using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignerEd : Ending
{
    public override bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat;
        return currentStat.design >= 800 && currentStat.sensibility >= 800;
    }
}
