using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGm_Plate : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    MiniGm_PlateManager miniPm;

    void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        miniPm = GameObject.Find("plates").GetComponent<MiniGm_PlateManager>();
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "blue" && miniPm.isEnded == false)
        {
            gameObject.tag = "red";
            changeColor_ToRed();
        }
        else if (gameObject.tag == "red" && miniPm.isEnded == false)
        {
            gameObject.tag = "blue";
            changeColor_ToBlue();
        }
    }

    public void changeColor_ToRed()
    {
        spriterenderer.color = new Color(255, 0, 0, 255);
    }

    public void changeColor_ToBlue()
    {
        spriterenderer.color = new Color(0, 0, 255, 255);
    }
}
