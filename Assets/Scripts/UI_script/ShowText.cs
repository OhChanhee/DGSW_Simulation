using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour
{
    public Text textComponent;
    public float startTime;

    // Start is called before the first frame update
    void Start()
    {
        string text = textComponent.text;
        textComponent.text = "";
        TaskManager.Delay(startTime,
        () =>
        {
            textComponent.text = text;
            UIEffect.ShowEachChar(textComponent, 0.1f);
        });
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
}
