using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpEd : MonoBehaviour, IEnding
{
    public bool CheckPossibility()
    {
        CharacterStat currentStat = CharacterManager.Get_instance().characterStat.clone;
        return false;
    }

    public void LoadEnding()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
