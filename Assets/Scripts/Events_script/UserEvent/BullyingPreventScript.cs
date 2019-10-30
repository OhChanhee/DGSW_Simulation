using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullyingPreventScript : SceneBase
{
    public Button submit;

    // Start is called before the first frame update
    new void Start()
    {
        nextScene = "Main";

        submit.onClick.AddListener(() => {
            // To do
            EndScene();
        });

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
