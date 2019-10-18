using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
    public Button[] Categorys = new Button[3];
    public GameObject Listitem;
    public Sprite[] CategoryImages = new Sprite[6];
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
            Categorys[i].onClick.AddListener(() =>
            {
                Click_Category(idx);
            });
        }
    }

    void UpdateCategory(Week week)
    {
        if (week.isWeekend == false)
        {
            Categorys[0].GetComponent<Image>().sprite = CategoryImages[0];
            Categorys[0].GetComponent<Category>().category = eCategory.Study;
            Categorys[1].GetComponent<Image>().sprite = CategoryImages[1];
            Categorys[1].GetComponent<Category>().category = eCategory.Leisure;
            Categorys[2].GetComponent<Image>().sprite = CategoryImages[2];
            Categorys[2].GetComponent<Category>().category = eCategory.Rest;
        }
        else
        {
            Categorys[0].GetComponent<Image>().sprite = CategoryImages[3];
            Categorys[0].GetComponent<Category>().category = eCategory.LeisureWeekend;
            Categorys[1].GetComponent<Image>().sprite = CategoryImages[4];
            Categorys[1].GetComponent<Category>().category = eCategory.Shopping;
            Categorys[2].GetComponent<Image>().sprite = CategoryImages[5];
            Categorys[2].GetComponent<Category>().category = eCategory.Visit;
        }
    }

    void Click_Category(int idx)
    {
        CurCategory = Categorys[idx].GetComponent<Category>().category;
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
