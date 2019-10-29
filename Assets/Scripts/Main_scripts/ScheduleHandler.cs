using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;
using System;

public class ScheduleHandler : MonoBehaviour
{
    public SpriteRenderer behaviour;
    public Slider progressBar;
    public Text descText;
    public GameObject scoreBoard;
    Coroutine dotRepeat;
    Coroutine showEachChar;
    List<Week> weekList;
    List<float> progressPointList;
    CharacterStat changement = CharacterStat.zero;

    Action onEndSchedule = () => { };

    // Start is called before the first frame update
    void Start()
    {
        weekList = GameObject.Find("dataHolder").GetComponent<Schedule>().weekList;
        Debug.Log(weekList);
        InitChangement();
        InitProgressPointList();
        progressBar.onValueChanged.AddListener((float value) => CheckSchedule(value));
        StartCoroutine(ProgressSchedule());
    }

    void Update()
    {
        onEndSchedule();
    }

    void InitChangement()
    {
        for(int i = 0; i < 4; i++)
        {
            Debug.Log(weekList[i]);
            changement += weekList[i].act.Changement;
        }
        
        CharacterManager.Get_instance().characterStat += changement;
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
            CharacterManager.Get_instance().curdate.week += 2;

            TaskManager.Delay(1f, () => {
                StopCoroutine(dotRepeat);
                StopCoroutine(showEachChar);

                Destroy(GameObject.Find("dataHolder"));
                behaviour.sprite = null;
                descText.text = "계속하려면 아무키를 입력하십시오...";

                scoreBoard.SetActive(true);

                onEndSchedule = () =>
                {
                    if (Input.anyKeyDown)
                    {
                        weekList.Clear();
                        SceneManager.LoadScene("Main");
                    }
                };
            });
        }
    }

    void UpdateSchedule()
    {
        Week curWeek = weekList[0];
        if (dotRepeat != null) StopCoroutine(dotRepeat);
        if (showEachChar != null) StopCoroutine(showEachChar);
        descText.text = curWeek.act.Description.text;
        showEachChar = UIEffect.ShowEachChar(descText, .1f, () => dotRepeat = UIEffect.DotRepeat(descText, .5f, 3));
        behaviour.sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + curWeek.act.actName);
    }
}