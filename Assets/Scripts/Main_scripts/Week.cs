using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Week : MonoBehaviour
{
    List<Dictionary<string, object>> data;
    public int NumOfWeek;
    public bool isWeekend;
    private Acting _act;
    public Acting act
    {
        get
        {
            return _act;
        }
        set
        {
            _act = value;

            GetComponent<Image>().sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + act.actName);
        }
    }

    void Start()
    {
        data = CSVReader.Read("csvFolder/Action");
        for (int i = 0; i < data.Count; i++)
        {
            if (CharacterManager.Get_instance().curdate.dateTime.Month.ToString() == data[i]["month"].ToString() &&
                (CharacterManager.Get_instance().grade.ToString() == data[i]["grade"].ToString() || "4" == data[i]["grade"].ToString()) &&
                CharacterManager.Get_instance().curdate.week.ToString() == data[i]["week"].ToString()
                )
            {
                _act.Title.text = data[i]["item_name"].ToString();
                _act.actName = data[i]["item_var_name"].ToString();
                _act.Description.text = data[i]["item_desc"].ToString();
            }
        }
        gameObject.GetComponent<Button>().onClick.AddListener(Choose_Week);
    }

    public void Choose_Week()
    {      
        if (CharacterManager.Get_instance().curdate.week == 1)
        {
            if (NumOfWeek == 1 || NumOfWeek == 2)
            {
                FindObjectOfType<DataManager>().curWeek = gameObject;
                   
            }
        }
        else if (CharacterManager.Get_instance().curdate.week == 3)
        {
            if (NumOfWeek == 3 || NumOfWeek == 4)
            {
                FindObjectOfType<DataManager>().curWeek = gameObject;
            }
        }
    }
}
