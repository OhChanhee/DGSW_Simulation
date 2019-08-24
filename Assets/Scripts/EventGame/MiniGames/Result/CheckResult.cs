using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckResult : MonoBehaviour
{
    public Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = PlayerPrefs.GetString("MinigameResult");
        PlayerPrefs.DeleteKey("MinigameResult");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
