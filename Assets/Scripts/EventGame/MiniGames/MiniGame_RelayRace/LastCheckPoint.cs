using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastCheckPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            MinigameResult.LoadResultScene(true, () =>
            {
                CharacterManager.Get_instance().characterStat.exercise += 200;
                CharacterManager.Get_instance().characterStat.fatigue += 20;
                CharacterManager.Get_instance().characterStat.hp -= 10;
            });
        }
    }
}
