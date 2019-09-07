using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DataManager : MonoBehaviour
{
    public Button[] Categorys = new Button[3];
    Week week;
    void Start()
    {
        for(int i = 0;i<3;i++)
        {
          Categorys[i].onClick.AddListener(() =>
          {

             // Categorys[i].GetComponent<Category>().category;
          });
        }
    }
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

    void UpdateCategory(Week week)
    {
        if (week.isWeekend == false)
        {
            //Categorys[0].image = Study이미지
            Categorys[0].GetComponent<Category>().category = eCategory.Study;
            //Categorys[1].image = Leisure이미지
            Categorys[1].GetComponent<Category>().category = eCategory.Leisure;
            //Categorys[2].image = Rest이미지
            Categorys[2].GetComponent<Category>().category = eCategory.Rest;
        }
        else
        {
            //Categorys[0].image = Leisure_weekend이미지
            Categorys[0].GetComponent<Category>().category = eCategory.Leisure_weekend;
            //Categorys[1].image = Shopping이미지
            Categorys[0].GetComponent<Category>().category = eCategory.Shopping;
            //Categorys[2].image = Visit이미지
            Categorys[0].GetComponent<Category>().category = eCategory.Visit;
        }
    }

    void UpdateActingList()
    {
        if(Categorys[0].GetComponent<Category>().category == eCategory.Study)
        {

        }
    }


}
