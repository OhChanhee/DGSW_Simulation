﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HandleStat : SceneBase
{
    public GameObject statTypes;
    public GameObject gaugeBars;
    public GameObject changes;
    public Button done;

    List<Text> statTypeList;
    List<Image> gaugeBarList;
    List<Text> changeList;

    List<Stat> statList;

    class Stat
    {
        public Text statType;
        public Image gaugeBar;
        public Text change;

        public Stat(Text statType, Image gaugeBar, Text change)
        {
            this.statType = statType;
            this.gaugeBar = gaugeBar;
            this.change = change;
        }
    }

    CharacterStat oldStat;

    // Start is called before the first frame update
    new void Start()
    {
        oldStat = FindObjectOfType<StatHolder>().oldStat;

        if(oldStat != null)
        {
            TaskManager.Delay(fadeInTime, () =>
            {
                foreach (Stat stat in statList)
                {
                    StartCoroutine(IncreaseStat(stat));
                }
            });
        }

        LoadStatInfoList();

        LoadStatList();

        UpdateStatList();

        nextScene = "Main";
        done.onClick.AddListener(() =>
        {
            EndScene();
        });

        base.Start();
    }

    void LoadStatInfoList()
    {
        LoadStatTypeList();

        LoadGaugeBarList();

        LoadChangeList();
    }

    void LoadStatTypeList()
    {
        statTypeList = new List<Text>();

        foreach (Transform statType in statTypes.transform)
        {
            statTypeList.Add(statType.gameObject.GetComponent<Text>());
        }
    }

    void LoadGaugeBarList()
    {
        gaugeBarList = new List<Image>();

        foreach (Transform gaugeBar in gaugeBars.transform)
        {
            gaugeBarList.Add(gaugeBar.gameObject.GetComponent<Image>());
        }
    }

    void LoadChangeList()
    {
        changeList = new List<Text>();

        foreach (Transform change in changes.transform)
        {
            changeList.Add(change.gameObject.GetComponent<Text>());
        }
    }

    void LoadStatList()
    {
        statList = new List<Stat>();

        for (int i = 0; i < Mathf.Min(statTypeList.Count, gaugeBarList.Count, changeList.Count); i++)
        {
            statList.Add(new Stat(statTypeList[i], gaugeBarList[i], changeList[i]));
        }
    }

    void UpdateStatList()
    {
        foreach (Stat stat in statList)
        {
            UpdateGaugeBar(stat, oldStat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGaugeBar(Stat stat, CharacterStat src)
    {
        stat.gaugeBar.fillAmount = src.GetStatRatio(stat.statType.name);
    }

    IEnumerator IncreaseStat(Stat stat)
    {
        PropertyInfo oldProperty = oldStat.GetType().GetProperty(stat.statType.name);
        PropertyInfo currentProperty = CharacterManager.Get_instance().characterStat.GetType().GetProperty(stat.statType.name);

        int amountOfChange = (int)currentProperty.GetValue(CharacterManager.Get_instance().characterStat) - (int)oldProperty.GetValue(oldStat);
        int normalized = Mathf.Clamp(amountOfChange, -1, 1);

        string sign = normalized > 0 ? "+" : "-";
        int scale = stat.statType.name.StartsWith("raw") ? 10 : 1;

        for (int i = 0; i <= Mathf.Abs(amountOfChange) && normalized != 0; i++)
        {
            oldProperty.SetValue(oldStat, (int)oldProperty.GetValue(oldStat) + Mathf.Clamp(amountOfChange, -1, 1));
            UpdateGaugeBar(stat, oldStat);
            stat.change.text = sign + (i / scale);

            yield return new WaitForSeconds(1 / 150f);
        }
    }
}
