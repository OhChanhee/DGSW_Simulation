using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : AIMovement
{
    public override void endCirculation()
    {
        MinigameResult.LoadResultScene(false, () =>
        {
            CharacterManager.Get_instance().characterStat.charm -= 100;
        });
    }
}
