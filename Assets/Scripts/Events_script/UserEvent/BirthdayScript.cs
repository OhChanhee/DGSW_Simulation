using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirthdayScript : SceneBase
{
    public Button submit;
    public Text text;

    void Awake()
    {
        text.text += "오늘은 " + CharacterManager.Get_instance().playerName + "의 생일입니다.";

        if (CharacterManager.Get_instance().characterStat.sociability > 100)
        {
            CharacterManager.Get_instance().characterStat.sensibility += 30;
            CharacterManager.Get_instance().characterStat.stress -= 30;

            text.text += "\n감수성이 30만큼 올랐다. 스트레스가 30만큼 내려갔다.";
        }
        else
        {
            text.text += "\n하지만 아무 일도 일어나지 않았다...";
        }
    }

    // Start is called before the first frame update
    new void Start()
    {
        nextScene = "Main";

        submit.onClick.AddListener(() => {
            EndScene();
        });

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
