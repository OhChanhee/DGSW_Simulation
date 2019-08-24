using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGm_Plate : MonoBehaviour
{
    
    private SpriteRenderer spriterenderer;
    MiniGm_PlateManager miniPm;
    public Sprite[] colorSprite;

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
            miniPm.blue_count--;
            miniPm.red_count++;
            changeColor_ToRed();
        }
        else if (gameObject.tag == "red" && miniPm.isEnded == false)
        {
            gameObject.tag = "blue";
            miniPm.red_count--;
            miniPm.blue_count++;
            changeColor_ToBlue();
        }
    }

    public void changeColor_ToRed()
    {
        spriterenderer.sprite = colorSprite[0];
    }

    public void changeColor_ToBlue()
    {
        spriterenderer.sprite = colorSprite[1];
    }

    /*public void textingCount()
    {
        foreach (GameObject i in plateList)
        {
            if (i.tag == "red")
            {
                
            }
            else if (i.tag == "blue")
            {
               
            }
        }
    }*/
}
