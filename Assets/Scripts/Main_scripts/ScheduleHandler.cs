using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleHandler : MonoBehaviour
{
    public SpriteRenderer behaviour;
    public Slider progressBar;
    public Text descText;
    CharacterStat changement = new CharacterStat();
    Coroutine dotRepeat;
    Coroutine showEachChar;
    List<Week> weekList;
    List<float> progressPointList;

    // Start is called before the first frame update
    void Start()
    {
        weekList = GameObject.Find("dataHolder").GetComponent<Schedule>().weekList;

        GetChangement();
        InitProgressPointList();
        progressBar.onValueChanged.AddListener((float value) => CheckSchedule(value));

        StartCoroutine(ProgressSchedule());
    }

    void GetChangement()
    {
        foreach (Week week in weekList)
        {
            changement += week.act.Changement;
            Debug.Log(week);
        }
    }

    void InitProgressPointList()
    {
        progressPointList = new List<float>();

        progressPointList.Add(0f);
        progressPointList.Add(5f * progressBar.maxValue / 14f);
        progressPointList.Add(7f * progressBar.maxValue / 14f);
        progressPointList.Add(12f * progressBar.maxValue / 14f);
    }

    IEnumerator ProgressSchedule()
    {
        UpdateSchedule();

        while(progressBar.value < progressBar.maxValue)
        {
            progressBar.value += progressBar.maxValue * Time.deltaTime / 10;

            yield return new WaitForEndOfFrame();
        }
    }

    void CheckSchedule(float value)
    {
        if(value > progressPointList[1])
        {
            progressPointList.RemoveAt(0);
            weekList.RemoveAt(0);
            UpdateSchedule();

            if (progressPointList.Count < 1) {
                progressBar.onValueChanged.RemoveListener(CheckSchedule);
                progressBar.onValueChanged.AddListener(CheckScheduleEnd);
            };
        }
    }

    void CheckScheduleEnd(float value)
    {
        if (value >= progressBar.maxValue)
        {

        }
    }

    void UpdateSchedule()
    {
        Week curWeek = weekList[0];

        if (dotRepeat != null) StopCoroutine(dotRepeat);
        if (showEachChar != null) StopCoroutine(showEachChar);

        descText.text = curWeek.act.Description.text;
        showEachChar = UIEffect.ShowEachChar(descText, .1f, () => dotRepeat = UIEffect.DotRepeat(descText, .5f, 2));
        behaviour.sprite = Resources.Load<Sprite>("Main/m_schedule/" + curWeek.act.ActName + "_" + curWeek.act.Category);
    }
}
