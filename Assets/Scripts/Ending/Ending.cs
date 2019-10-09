using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Ending : ScriptableObject
{
    public abstract bool CheckPossibility();

    public void LoadEnding()
    {
        SceneManager.LoadScene(GetType().Name);
        Debug.Log("Test");
    }
}