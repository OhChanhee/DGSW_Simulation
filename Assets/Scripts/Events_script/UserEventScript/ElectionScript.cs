using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectionScript : EventScript
{
    public Button yes;
    public Button no;

    // Start is called before the first frame update
    void Start()
    {
        yes.onClick.AddListener(() =>
        {
            // To do
            EndScene();
        });

        no.onClick.AddListener(() =>
        {
            EndScene();
        });
    }
}
