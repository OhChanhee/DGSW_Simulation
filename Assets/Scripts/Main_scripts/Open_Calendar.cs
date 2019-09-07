using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Open_Calendar : MonoBehaviour
{
    public Button playbtn;
    public GameObject calendar;

    void Start()
    {
        playbtn.onClick.AddListener(Onclick_Calendar_btn);
    }
    public void Onclick_Calendar_btn()
    {
        calendar.SetActive(true);
    }
}
