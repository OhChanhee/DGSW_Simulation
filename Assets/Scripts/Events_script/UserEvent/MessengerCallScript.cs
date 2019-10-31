using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class MessengerCallScript : SceneBase
{
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    new void Start()
    {
        nextScene = "Main";

        yes.onClick.AddListener(() =>
        {
            CharacterManager.Get_instance().hasTeam = true;

            AddStat("suggestionMessenger");

            EndScene();
        });

        no.onClick.AddListener(() =>
        {
            EndScene();
        });

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
