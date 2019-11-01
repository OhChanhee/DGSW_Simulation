using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Week : MonoBehaviour
{
    public int NumOfWeek;
    public bool isWeekend;

    List<Dictionary<string, object>> fixedEventData;

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
        InitWeek();

        InitEventData();

        CheckEvent();

        gameObject.GetComponent<Button>().onClick.AddListener(Choose_Week);
    }

    void InitWeek()
    {
        int curWeek = CharacterManager.Get_instance().curdate.week;

        if (NumOfWeek == curWeek || NumOfWeek == curWeek + 1)
            GetComponent<Button>().interactable = true;
    }

    void InitEventData()
    {
        fixedEventData = CSVReader.Read("csvFolder/FixedEvent");
    }

    void CheckEvent()
    {
        for (int i = 0; i < fixedEventData.Count; i++)
        {
            if (hasFixedEvent(i))
            {
                Act act = new Act();

                act.Title = fixedEventData[i]["item_name"].ToString();
                act.Name = fixedEventData[i]["item_var_name"].ToString();
                act.Description = fixedEventData[i]["item_desc"].ToString();
                act.Changement = CharacterStat.zero;
                act.IsEvent = true;

                GetComponent<Button>().interactable = false;

                this.act = act;
            }
        }
    }

    bool hasFixedEvent(int idx)
    {
        return (CharacterManager.Get_instance().curdate.dateTime.Month.ToString() == fixedEventData[idx]["month"].ToString() &&
        (CharacterManager.Get_instance().grade.ToString() == fixedEventData[idx]["grade"].ToString() || "4" == fixedEventData[idx]["grade"].ToString()) &&
        GetComponent<Week>().NumOfWeek.ToString() == fixedEventData[idx]["week"].ToString() &&
        !isWeekend);
    }

    public void Choose_Week()
    {
        FindObjectOfType<DataManager>().curWeek = gameObject;
    }
}
