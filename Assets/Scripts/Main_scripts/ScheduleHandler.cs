using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleHandler : MonoBehaviour
{
    public SpriteRenderer behaviour;
    public Slider progressBar;
    public Text descText;
    Coroutine dotRepeat;
    Coroutine showEachChar;
    List<Week> weekList;
    List<float> progressPointList;

    // Start is called before the first frame update
    void Start()
    {
        weekList = GameObject.Find("dataHolder").GetComponent<Schedule>().weekList;
        InitProgressPointList();
        progressBar.onValueChanged.AddListener((float value) => CheckSchedule(value));
        StartCoroutine(ProgressSchedule());
    }

    void InitProgressPointList()
    {
        progressPointList = new List<float>();

        progressPointList.Add(0f);
        progressPointList.Add(5f / 14f);
        progressPointList.Add(7f / 14f);
        progressPointList.Add(12f / 14f);
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
        if (value > progressPointList[1])
        {
            progressPointList.RemoveAt(0);
            weekList.RemoveAt(0);

            if (weekList.Count <= 1 || progressPointList.Count <= 1)
            {
                progressBar.onValueChanged.RemoveAllListeners();
                progressBar.onValueChanged.AddListener(CheckScheduleEnd);
            }

            UpdateSchedule();
        }
    }

    void CheckScheduleEnd(float value)
    {
        if(value >= progressBar.maxValue)
        {
            StopCoroutine(dotRepeat);
            StopCoroutine(showEachChar);
        }
    }

    void UpdateSchedule()
    {
        Week curWeek = weekList[0];
        if (dotRepeat != null) StopCoroutine(dotRepeat);
        if (showEachChar != null) StopCoroutine(showEachChar);
        descText.text = curWeek.act.Description.text;
        showEachChar = UIEffect.ShowEachChar(descText, .1f, () => dotRepeat = UIEffect.DotRepeat(descText, .5f, 3));
        behaviour.sprite = Resources.Load<Sprite>("Main/m_schedule/" + curWeek.act.actName + "_" + curWeek.act.category);
    }
}