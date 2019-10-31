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

    Coroutine showEachChar;
    GameObject dataHolder;
    List<Act> actList;
    List<float> progressPointList;
    string nextScene = "Main";

    Action onEndSchedule;
    
    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.Find("dataHolder");
        actList = dataHolder.GetComponent<Schedule>().actList;
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
        progressBar.value = dataHolder.GetComponent<Schedule>().progressPoint;

        progressPointList = new List<float>()
        {
            0f,
            .25f,
            .5f,
            .75f
        };

        progressPointList.ForEach((float value) =>
        {
            value *= progressBar.maxValue;
        });

        progressPointList = progressPointList.FindAll((float value) => { return value > progressBar.value - progressPointList[1]; });
    }

    IEnumerator ProgressSchedule()
    {
        UpdateSchedule();

        while(progressBar.value < progressBar.maxValue)
        {
            progressBar.value += progressBar.maxValue * Time.deltaTime / 5;

            yield return new WaitForEndOfFrame();
        }
    }

    void CheckSchedule(float value)
    {
        if (value > progressPointList[1])
        {
            if (actList[0].IsEvent)
            {
                dataHolder.GetComponent<Schedule>().progressPoint = progressBar.value;
                SceneManager.LoadScene(actList[0].Name);
            }

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
        if (value < progressBar.maxValue) return;

        CharacterManager.Get_instance().curdate.week += 2;

        TaskManager.Delay(1f, EndSchedule);
    }

    void EndSchedule()
    {
        if (showEachChar != null) StopCoroutine(showEachChar);

        Destroy(dataHolder);
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
    }

    void UpdateSchedule()
    {
        Act act = actList[0];

        if (showEachChar != null) StopCoroutine(showEachChar);
        CharacterManager.Get_instance().characterStat += act.Changement;

        descText.text = act.Description;
        showEachChar = UIEffect.ShowEachChar(descText, .05f);
        behaviour.sprite = Resources.Load<Sprite>("Main/m_schedule/Category/m_" + act.Name);

        CheckEvent(act);
    }

    void CheckEvent(Act act)
    {
        if (act.IsEvent)
        {
            nextScene = act.Name;
        }
    }
}