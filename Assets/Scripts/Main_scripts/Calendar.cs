using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calendar : Tap
{
    public Button exit_btn;   
    void Start()
    {
        exit_btn.onClick.AddListener(Close_tap);
    }
}
