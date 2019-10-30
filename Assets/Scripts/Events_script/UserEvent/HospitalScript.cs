using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HospitalScript : SceneBase
{
    public Button submit;

    // Start is called before the first frame update
    new void Start()
    {
        submit.onClick.AddListener(() => {
            nextScene = "Main";
            EndScene();
        });

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
