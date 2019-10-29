using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Week : MonoBehaviour
{
    List<Dictionary<string, object>> data;
    public int NumOfWeek;
    public bool isWeekend;
    private Act _act;
    public Act act
    {
        get
        {
            return _act;
        }
        set
        {
            _act = value;

            GetComponent<Image>().sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + act.Name);
        }
    }

    void Start()
    {
        data = CSVReader.Read("csvFolder/Action");
        for (int i = 0; i < data.Count; i++)
        {
            if (isEvent(i))
            {
                Act act = new Act();

                act.Title = data[i]["item_name"].ToString();
                act.Name = data[i]["item_var_name"].ToString();
                act.Description = data[i]["item_desc"].ToString();
                act.Changement = CharacterStat.zero;              
                act.IsEvent = true;

                GetComponent<Button>().interactable = false;

                this.act = act;
            }
        }

        gameObject.GetComponent<Button>().onClick.AddListener(Choose_Week);
    }

    bool isEvent(int idx)
    {
        return (CharacterManager.Get_instance().curdate.dateTime.Month.ToString() == data[idx]["month"].ToString() &&
        (CharacterManager.Get_instance().grade.ToString() == data[idx]["grade"].ToString() || "4" == data[idx]["grade"].ToString()) &&
        GetComponent<Week>().NumOfWeek.ToString() == data[idx]["week"].ToString() &&
        !isWeekend);
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
