using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : AIMovement
{
    public override void endCirculation()
    {
        PlayerPrefs.SetString("MinigameResult", "Failure");

        SceneManager.LoadScene("Result");
    }
}
