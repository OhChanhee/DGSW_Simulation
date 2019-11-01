using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirthdayScript : EventScript
{
    public Button submit;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Get_instance().birthday.grade++;

        submit.onClick.AddListener(() => {
            AddStat("birthday");

            EndScene();
        });
    }
}
