using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Week : MonoBehaviour
{
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

            GetComponent<Image>().sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + act.ActName);
        }
    }

    void Start()
    {
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
