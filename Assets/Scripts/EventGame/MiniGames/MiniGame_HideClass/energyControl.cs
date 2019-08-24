using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyControl : MonoBehaviour
{
    [HideInInspector]
    public Image gauge;
    [HideInInspector]
    public float minusValue = 2.5f;
    public float plusValue = 3f;
    public int speed = 2;
    doGame dogame;

    void Start()
    {
        dogame = GameObject.Find("student").GetComponent<doGame>();
        gauge = GameObject.Find("gaugeBar").GetComponent<Image>();
        gauge.fillAmount = 1f;
    }

    void Update()
    {
        subTractingValue();
    }

    public void subTractingValue()
    {
        if(gauge.fillAmount != 0 && dogame.isPlus == false)
        {
            Debug.Log(gauge.fillAmount);
            gauge.fillAmount -= minusValue * Time.deltaTime * speed;
        }
        else if(gauge.fillAmount != 0 && dogame.isPlus == true)
        {
            Debug.Log(gauge.fillAmount);
            gauge.fillAmount += plusValue * Time.deltaTime * speed;
        }
    }
}
