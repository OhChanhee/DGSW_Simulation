using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Confirm : MonoBehaviour
{
    public Button confirmButton;
    GameObject dataHolder;
    Schedule schedule;
    Week[] weeks;

    // Start is called before the first frame update
    void Start()
    {
        confirmButton.onClick.AddListener(ConfirmSchedule);
        dataHolder = new GameObject("dataHolder");
        schedule = dataHolder.AddComponent<Schedule>();
        weeks = FindObjectsOfType<Week>();
        weeks = System.Array.FindAll(weeks, (week) => 
        {
            int curWeekIdx = (CharacterManager.Get_instance().curdate.week - 1) * 2;

            int numOfWeek = System.Array.IndexOf(weeks, week);

            return curWeekIdx < numOfWeek && numOfWeek < curWeekIdx;
        });
    }

    void ConfirmSchedule()
    {
        if (IsAllSelected())
        {
            DontDestroyOnLoad(dataHolder);

            foreach (Week week in weeks)
            {
                schedule.weekList.Add(week);
            }

            SceneManager.LoadScene("Main_progress");
        }
    }

    bool IsAllSelected()
    {
        for(int i = 0; i < weeks.Length; i++)
        {
            if(weeks[i].act == null)
            {
                return false;
            }
        }

        return true;
    }
}
