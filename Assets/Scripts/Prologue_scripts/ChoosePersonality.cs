using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePersonality : EventScript
{
    public Button yes;
    public Button no;
    public Button report;
    public Button stop;
    public Text textComponent;

    Coroutine showEachChar;

    bool isExtroverted;
    bool isEmotional;

    string content;
    string[] contentList;

    void Awake()
    {
        content = textComponent.text;
        contentList =  content.Split('|');
        textComponent.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        yes.onClick.AddListener(ChooseY);
        no.onClick.AddListener(ChooseN);
        report.onClick.AddListener(ChooseReport);
        stop.onClick.AddListener(ChooseStop);

        report.gameObject.SetActive(false);
        stop.gameObject.SetActive(false);

        textComponent.text = contentList[0];
        showEachChar = UIEffect.ShowEachChar(textComponent, .1f);
    }

    void ChangeQuestion()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        report.gameObject.SetActive(true);
        stop.gameObject.SetActive(true);
        StopCoroutine(showEachChar);

        textComponent.text = contentList[1];
        UIEffect.ShowEachChar(textComponent, .1f);
    }

    void Submit()
    {
        byte extroverted = isExtroverted ? (byte)2 : (byte)0;
        byte emotional = isEmotional ? (byte)1 : (byte)0;

        CharacterManager.Get_instance().personality = (Personality)((int)(extroverted | emotional));

        EndScene();
    }

    void ChooseY()
    {
        isExtroverted = true;
        ChangeQuestion();
    }

    void ChooseN()
    {
        isExtroverted = false;
        ChangeQuestion();
    }

    void ChooseStop()
    {
        isEmotional = true;
        Submit();
    }

    void ChooseReport()
    {
        isEmotional = false;
        Submit();
    }
}
