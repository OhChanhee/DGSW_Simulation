using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Event : ScriptableObject
{
    public abstract bool HasEvent();

    public void LoadEvent()
    {
        SceneManager.LoadScene(GetType().Name);
    }
}
