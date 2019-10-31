using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class ChooseDate : EventScript
{
    public Text tYear, tMonth;
    //public RawImage calendar;
    GameObject[] objList;
    int year, month, day;

    void Awake()
    {
        tYear.text = (System.DateTime.Now.Year - 16).ToString();
        tMonth.text = System.DateTime.Now.Month.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        objList = GameObject.FindGameObjectsWithTag("Day");

        foreach (GameObject obj in objList)
        {
            obj.GetComponentInParent<Button>().onClick.AddListener(() =>
            {
                day = Int32.Parse(obj.GetComponentInChildren<Text>().text);
                CharacterManager.Get_instance().birthday.gamedate.dateTime = new DateTime(year, month, day);
                CharacterManager.Get_instance().birthday.gamedate.week = Math.Min(day / 7 + 1, 4);
                CharacterManager.Get_instance().curdate.dateTime = new DateTime(CharacterManager.Get_instance().birthday.gamedate.dateTime.Year + 16, 3, 1);
                nextScene = "Prologue_personality";

                EndScene();
            });
        }

        Show();
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
            obj.GetComponentInChildren<Text>().text = "";
        }

        for (int i = 1, index = dayOfWeek.GetHashCode(); i <= maxDay; i++, index++)
        {
            Array.Sort(objList, (GameObject obj1, GameObject obj2) => int.Parse(obj1.name) - int.Parse(obj2.name));
            objList[index].GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
