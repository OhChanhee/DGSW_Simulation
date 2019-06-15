using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateHandle : MonoBehaviour
{
    public Button up, down;
    public Text text;
    public RawImage calendar;
    int curValue;
    ChooseDate chooseDate;

    // Start is called before the first frame update
    void Start()
    {
        up.onClick.AddListener(Up);
        down.onClick.AddListener(Down);
        curValue = System.Int32.Parse(text.text);
        chooseDate = calendar.GetComponent<ChooseDate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Up()
    {
        curValue += 1;
        text.text = curValue.ToString();
        chooseDate.Show();
    }
    
    void Down()
    {
        curValue -= 1;
        text.text = curValue.ToString();
        chooseDate.Show();
    }
}
