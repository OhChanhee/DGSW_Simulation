using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose_Title : MonoBehaviour
{
    public GameObject option;
    public GameObject exit_Tap;
    public GameObject load_Tap;
    public void OnClick_NewStart()
    {
        GetComponent<Text>().color = Color.red;
    }

    public void OnClick_Load()
    {
        load_Tap.SetActive(true);
    }

    public void OnClick_Option()
    {
        option.SetActive(true);
    }

    public void OnClick_Exit()
    {
        exit_Tap.SetActive(true);
    }
}
