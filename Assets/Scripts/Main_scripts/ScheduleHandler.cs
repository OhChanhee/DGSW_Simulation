using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleHandler : MonoBehaviour
{
    public SpriteRenderer behaviour;
    public Slider progressBar;
    List<string> actList;

    // Start is called before the first frame update
    void Start()
    {
        //actList = GameObject.Find("obj").GetComponent<Info>().???;
        progressBar.onValueChanged.AddListener((float value) => CheckSchedule(value));
        StartCoroutine(ProgressSchedule());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ProgressSchedule()
    {
        while(progressBar.value < 1)
        {
            progressBar.value += Time.deltaTime / 10;

            yield return new WaitForEndOfFrame();
        }
    }

    void CheckSchedule(float value)
    {
        value /= .5f;
        float progressRatio = value - ((int)value);

        bool isWeekend = progressRatio > (5f / 7f);

        if (isWeekend)
        {
            // To do
        }
        else
        {
            // To do
        }
    }
}
