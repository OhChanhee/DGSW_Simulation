using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class DataManager : MonoBehaviour
{
    const int ButtonCount = 3;
    public Button[] Categories = new Button[ButtonCount];
    public GameObject Listitem;
    public eCategory[] WeekdayCategories = new eCategory[ButtonCount];
    public eCategory[] WeekendCategories = new eCategory[ButtonCount];
    public GameObject Contents;
    public GameObject WeekHolder;
    List<Dictionary<string, object>> data;
    Week week;
    eCategory curCategory;

    GameObject _curWeek;
    public GameObject curWeek
    {
        get
        {
            return _curWeek;
        }
        set
        {
            _curWeek = value;
            week = _curWeek.GetComponent<Week>();
            UpdateCategory(week);
        }
    }

    void Start()
    {
        data = CSVReader.Read("csvFolder/Action");
        foreach(Button button in WeekHolder.GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(() => ClearContents());
        }

        for (int i = 0; i < 3; i++) 
        {
            int idx = i;
            Categories[i].onClick.AddListener(() =>
            {
                Click_Category(idx);
            });
        }
    }

    void UpdateCategory(Week week)
    {
        eCategory[] categories = week.isWeekend ? WeekendCategories : WeekdayCategories;

        for (int i = 0; i < ButtonCount; i++) 
        {
            string categoryName = categories[i].ToString();
            categoryName = categoryName.EndsWith("Weekend") ? categoryName.Replace("Weekend", "") : categoryName;

            Categories[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Main/m_schedule/m_ct" + categoryName);
            Categories[i].GetComponent<Category>().category = categories[i];
        }
    }

    void Click_Category(int idx)
    {
        curCategory = Categories[idx].GetComponent<Category>().category;
        UpdateActingList();
    }

    void UpdateActingList()
    {
        ClearContents();

        InsertActData();
    }

    void ClearContents()
    {
        for (int i = 0; i < Contents.transform.childCount; i++)
        {
            Contents.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void InsertActData()
    {
        for (int i = 0; i < data.Count; i++)
        {
            string[] splitedData = data[i]["item_var_name"].ToString().Split(new char[] { '_' });

            if (splitedData.Length > 1 && splitedData[1] == curCategory.ToString())
            {
                GameObject obj = Instantiate(Listitem);
                obj.transform.SetParent(Contents.transform);

                Acting acting = obj.GetComponent<Acting>();

                acting.Title.text = data[i]["item_name"].ToString();
                acting.Description.text = data[i]["item_desc"].ToString();
                acting.actName = splitedData[0];
                acting.category = curCategory;
                acting.Changement = GetChangement(i);

                obj.GetComponent<Image>().sprite = Resources.Load("Main/m_schedule/" + data[i]["item_var_name"], typeof(Sprite)) as Sprite;

                obj.GetComponent<Button>().onClick.AddListener(() => 
                {
                    curWeek.GetComponent<Week>().act = new Act(acting);
                });
            }
        }
    }

    

    CharacterStat GetChangement(int idx)
    {
        CharacterStat result = CharacterStat.zero;
        Type type = typeof(CharacterStat);

        foreach(PropertyInfo property in type.GetProperties())
        {
            string propertyName = property.Name;
            if (propertyName.StartsWith("raw") || property.SetMethod == null)
            {
                continue;
            }

            object value = data[idx][propertyName];

            if (value.ToString().Length == 0) continue;
            property.SetValue(result, int.Parse(data[idx][propertyName].ToString()));
        }

        return result;
    }
}
