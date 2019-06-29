using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Election : SceneBase
{
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    new void Start()
    {
        nextScene = "Main";

        yes.onClick.AddListener(() =>
        {
            // To do
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
