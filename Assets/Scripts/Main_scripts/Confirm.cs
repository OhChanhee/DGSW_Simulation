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
        System.Array.Sort(weeks, (Week week1, Week week2) =>
        {
            int weekIdx1= week1.NumOfWeek * 2 + (week1.isWeekend ? 1 : 0);
            int weekIdx2 = week2.NumOfWeek * 2 + (week2.isWeekend ? 1 : 0);

            return weekIdx1 - weekIdx2;
        });
    }

    void ConfirmSchedule()
    {
        if (IsAllSelected())
        {
            DontDestroyOnLoad(dataHolder);

            int curWeekIdx = (CharacterManager.Get_instance().curdate.week - 1) * 2;
            Week[] weekList = new Week[4];
            System.Array.Copy(weeks, curWeekIdx, weekList, 0, 4);

            foreach (Week week in weekList)
            {
                Debug.Log(week);
                schedule.actList.Add(new Act(week.acting));
            }

            SceneManager.LoadScene("Main_progress");
        }
    }

    bool IsAllSelected()
    {
        int curWeekIdx = (CharacterManager.Get_instance().curdate.week - 1) * 2;

        for (int i = curWeekIdx; i < curWeekIdx + 3; i++)
        {
            if(weeks[i].acting == null)
            {
                return false;
            }
        }

        return true;
    }
}
