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
    private bool isWin = false;
    private bool isEnd = false;

    void Start()
    {
        TCtrl = GameObject.Find("professor(Clone)").GetComponent<teacherControl>();
        dogame = GameObject.Find("student").GetComponent<doGame>();
        gauge = GameObject.Find("gaugeBar").GetComponent<Image>();
        gauge.fillAmount = 0.5f;
    }

    void Update()
    {
        if(isEnd == false)
        {
            if (TCtrl.isFinish == false && gauge.fillAmount < 1f)
            {
                subTractingValue();
            }
            else if (TCtrl.isFinish == true)
            {
                //Debug.Log("끝!!!");
                isWin = false;
                isEnd = true;
            }
            else if (gauge.fillAmount == 1f)
            {
                isWin = true;
                isEnd = true;
            }
        } else {
            MinigameResult.LoadResultScene(isWin, setStat);
        }
    }
    public void setStat()
    {
        CharacterManager.Get_instance().characterStat.intelligence -= 15;
        CharacterManager.Get_instance().characterStat.charm += 5;
        CharacterManager.Get_instance().characterStat.stress += 10;
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
