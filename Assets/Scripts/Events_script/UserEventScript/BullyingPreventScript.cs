using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullyingPreventScript : EventScript
{
    public Button submit;

    // Start is called before the first frame update
    void Start()
    {
        submit.onClick.AddListener(() => {
            // To do
            EndScene();
        });
    }
}
