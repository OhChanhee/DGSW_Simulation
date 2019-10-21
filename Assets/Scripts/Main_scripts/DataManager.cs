using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
    const int ButtonCount = 3;
    public Button[] Categories = new Button[ButtonCount];
    public GameObject Listitem;
    //public Sprite[] CategoryImages = new Sprite[6];
    public eCategory[] WeekdayCategories = new eCategory[ButtonCount];
    public eCategory[] WeekendCategories = new eCategory[ButtonCount];
    public GameObject contents;
    List<Dictionary<string, object>> data;
    Week week;
    eCategory CurCategory;

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
        //Listitem = Listitem.GetComponent<Acting>();
        for (int i = 0;i<3;i++)
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
        /*
         if (week.isWeekend == false)
        {
            Categories[0].GetComponent<Image>().sprite = CategoryImages[0];
            Categories[0].GetComponent<Category>().category = eCategory.Study;
            Categories[1].GetComponent<Image>().sprite = CategoryImages[1];
            Categories[1].GetComponent<Category>().category = eCategory.Leisure;
            Categories[2].GetComponent<Image>().sprite = CategoryImages[2];
            Categories[2].GetComponent<Category>().category = eCategory.Rest;
        }
        else
        {
            Categories[0].GetComponent<Image>().sprite = CategoryImages[3];
            Categories[0].GetComponent<Category>().category = eCategory.LeisureWeekend;
            Categories[1].GetComponent<Image>().sprite = CategoryImages[4];
            Categories[1].GetComponent<Category>().category = eCategory.Shopping;
            Categories[2].GetComponent<Image>().sprite = CategoryImages[5];
            Categories[2].GetComponent<Category>().category = eCategory.Visit;
        }
        */

        eCategory[] categories = week.isWeekend ? WeekendCategories : WeekdayCategories;

        for(int i = 0; i < ButtonCount; i++)
        {
            string categoryName = categories[i].ToString();
            categoryName = categoryName.EndsWith("Weekend") ? categoryName.Replace("Weekend", "") : categoryName;

            Categories[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Main/m_schedule/m_ct" + categoryName);
            Categories[i].GetComponent<Category>().category = categories[i];
        }
    }

    void Click_Category(int idx)
    {
        CurCategory = Categories[idx].GetComponent<Category>().category;
        UpdateActingList();
    }

    void UpdateActingList()
    {
        InitContents();

        InsertActData();
    }

    void InitContents()
    {
        for (int i = 0; i < contents.transform.childCount; i++)
        {
            Destroy(contents.transform.GetChild(i).gameObject);
        }
    }

    void InsertActData()
    {
        for (int i = 0; i < data.Count; i++)
        {
            string[] splitedData = data[i]["item_var_name"].ToString().Split(new char[] { '_' });

            if (splitedData.Length > 1 && splitedData[1] == CurCategory.ToString())
            {
                GameObject obj = Instantiate(Listitem);
                obj.transform.SetParent(contents.transform);
                obj.GetComponent<Acting>().Title.text = data[i]["item_name"].ToString();
                obj.GetComponent<Acting>().Description.text = data[i]["item_desc"].ToString();
                obj.GetComponent<Image>().sprite = Resources.Load("Main/m_schedule/" + data[i]["item_var_name"], typeof(Sprite)) as Sprite;
            }
        }
    }
}
