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
    List<Act> actList;
    List<float> progressPointList;
    string nextScene;
    bool hasEvent;

    Action onEndSchedule;
    
    // Start is called before the first frame update
    void Start()
    {
        nextScene = "Main";
        actList = GameObject.Find("dataHolder").GetComponent<Schedule>().actList;
        InitProgressPointList();
        progressBar.onValueChanged.AddListener((float value) => CheckSchedule(value));
        StartCoroutine(ProgressSchedule());
        onEndSchedule += () => { };
    }

    void Update()
    {
        onEndSchedule();
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
            actList.RemoveAt(0);

            if (actList.Count <= 1 || progressPointList.Count <= 1)
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
                        actList.Clear();
                        SceneManager.LoadScene(nextScene);
                    }
                };
            });
        }
    }

    void UpdateSchedule()
    {
        Act act = actList[0];
        if (dotRepeat != null) StopCoroutine(dotRepeat);
        if (showEachChar != null) StopCoroutine(showEachChar);
        CharacterManager.Get_instance().characterStat += act.Changement;

        descText.text = act.Description;
        showEachChar = UIEffect.ShowEachChar(descText, .1f, () => 
        {
            if(!act.IsEvent) dotRepeat = UIEffect.DotRepeat(descText, .5f, 3);
        });
        behaviour.sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + act.Name);

        CheckEvent(act);
    }

    void CheckEvent(Act act)
    {
        if (act.IsEvent)
        {
            hasEvent = true;

            nextScene = act.Name;
        }
    }
}