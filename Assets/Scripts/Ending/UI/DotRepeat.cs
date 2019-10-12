using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotRepeat : MonoBehaviour
{
    public Text textComponent;
    string textContent;
    string dots;

    void Start()
    {
        textContent = textComponent.text;
    }

    // Update is called once per frame
    void Update()
    {
        dots = "";
        for(int i = GetRangeByTime(.5f, 3) ; i > 0; i--)
        {
            dots += ".";
        }

        textComponent.text = textContent + dots;
    }

    int GetRangeByTime(float unit, int max)
    {
        int valueByTime = (int)(Time.time / unit);
        return valueByTime % (max + 1); 
    }
}
