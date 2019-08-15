using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : AIMovement
{
    public override void endCirculate()
    {
        Debug.Log("Lose");
        //SceneManager.LoadScene("Main");
    }
}
