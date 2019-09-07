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
    teacherControl TCtrl;
    doGame dogame;

    void Start()
    {
        TCtrl = GameObject.Find("professor(Clone)").GetComponent<teacherControl>();
        dogame = GameObject.Find("student").GetComponent<doGame>();
        gauge = GameObject.Find("gaugeBar").GetComponent<Image>();
        gauge.fillAmount = 1f;
    }

    void Update()
    {
        if(TCtrl.isFinish == false)
        {
            subTractingValue();
        }
        else
        {
            Debug.Log("끝!!!");
        }
    }

    public void subTractingValue()
    {
        if(gauge.fillAmount != 0 && dogame.isPlus == false)
        {
            gauge.fillAmount -= minusValue * Time.deltaTime * speed;
        }
        else if(gauge.fillAmount != 0 && dogame.isPlus == true)
        {
            gauge.fillAmount += plusValue * Time.deltaTime * speed;
        }
        else if(gauge.fillAmount == 0)
        {
            gauge.fillAmount = 0;
            TCtrl.isFinish = true;
        }
    }
}
