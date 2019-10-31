using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirthdayScript : SceneBase
{
    public Button submit;

    // Start is called before the first frame update
    new void Start()
    {
        nextScene = "Main";

        CharacterManager.Get_instance().birthday.grade++;

        submit.onClick.AddListener(() => {
            AddStat("birthday");

            EndScene();
        });

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
