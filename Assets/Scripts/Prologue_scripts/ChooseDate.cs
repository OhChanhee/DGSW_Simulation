using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class ChooseDate : SceneBase
{
    public Text tYear, tMonth;
    public RawImage calendar;
    GameObject[] objList;
    int year, month, day;

    // Start is called before the first frame update
    new void Start()
    {
        objList = GameObject.FindGameObjectsWithTag("Day");

        foreach (GameObject obj in objList)
        {
            obj.GetComponentInParent<Button>().onClick.AddListener(() =>
            {
                day = Int32.Parse(obj.GetComponent<Text>().text);
                CharacterManager.Get_instance().birthday = new DateTime(year, month, day);
                nextScene = "Prologue_personality";
                base.EndScene();
            });
        }

        Show();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateDate()
    {
        year = Int32.Parse(tYear.text);
        month = Int32.Parse(tMonth.text);
    }

    public void Show()
    {
        UpdateDate();
        DateTime dat = new DateTime(year, month, 1);
        DayOfWeek dayOfWeek = dat.DayOfWeek;
        int maxDay = DateTime.DaysInMonth(year, month);
        
        GameObject[] objList = GameObject.FindGameObjectsWithTag("Day");

        foreach(GameObject obj in objList)
        {
            obj.GetComponent<Text>().text = "";
        }

        for (int i = 1, index = dayOfWeek.GetHashCode(); i <= maxDay; i++, index++)
        {
            objList[index].GetComponent<Text>().text = i.ToString();
        }
    }
}
