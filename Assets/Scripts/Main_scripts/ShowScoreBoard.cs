using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreBoard : MonoBehaviour
{
    public GameObject StatTypes;
    public GameObject GaugeBars;
    public GameObject Changes;

    List<Text> statTypeList;
    List<Image> gaugeBarList;
    List<Text> changeList;

    List<Stat> statList;

    CharacterStat displayStat;

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

    // Start is called before the first frame update
    void Start()
    {
        displayStat = CharacterStat.zero;

        LoadStatInfoList();

        LoadStatList();

        foreach (Stat stat in statList) StartCoroutine(IncreaseStat(stat));
    }

    // Update is called once per frame
    void Update()
    {
        
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

        foreach (Transform statType in StatTypes.transform) statTypeList.Add(statType.gameObject.GetComponent<Text>());
    }

    void LoadGaugeBarList()
    {
        gaugeBarList = new List<Image>();

        foreach (Transform gaugeBar in GaugeBars.transform) gaugeBarList.Add(gaugeBar.gameObject.GetComponent<Image>());
    }

    void LoadChangeList()
    {
        changeList = new List<Text>();

        foreach (Transform change in Changes.transform) changeList.Add(change.gameObject.GetComponent<Text>());
    }

    void LoadStatList()
    {
        statList = new List<Stat>();

        for (int i = 0; i < Mathf.Min(statTypeList.Count, gaugeBarList.Count, changeList.Count); i++) statList.Add(new Stat(statTypeList[i], gaugeBarList[i], changeList[i]));
    }

    void UpdateGaugeBarList()
    {
        foreach (Stat stat in statList) UpdateGaugeBar(stat, displayStat);
    }

    void UpdateGaugeBar(Stat stat, CharacterStat src)
    {
        stat.gaugeBar.fillAmount = src.GetStatRatio(stat.statType.name);
    }

    IEnumerator IncreaseStat(Stat stat)
    {
        PropertyInfo property = typeof(CharacterStat).GetProperty(stat.statType.name);
        int scale = stat.statType.name.StartsWith("raw") ? CharacterStat.MAX_STAT / CharacterStat.MAX_HEALTH : 1;
        int curValue = (int)property.GetValue(CharacterManager.Get_instance().characterStat);

        int value = (int)property.GetValue(displayStat);
        int unit = 100;

        while(unit > 0)
        {
            while (0 < curValue / unit)
            {
                value += unit;
                property.SetValue(displayStat, value);
                stat.change.text = ((int)property.GetValue(displayStat) / scale).ToString();
                curValue -= unit;

                UpdateGaugeBar(stat, displayStat);

                yield return new WaitForSeconds(.1f);
            }

            unit /= 10;
        }
    }
}
