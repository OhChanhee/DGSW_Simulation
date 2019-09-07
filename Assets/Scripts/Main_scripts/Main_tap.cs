using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_tap : MonoBehaviour
{
    public GameObject Pause_Tap;
    public GameObject option;
    public GameObject SaveLoad_Tap;

    public void OnClick_Pause_Tap()
    {
        Pause_Tap.SetActive(true);
    }

    public void OnClick_Continue()
    {
        Pause_Tap.SetActive(false);
    }

    public void OnClick_SaveLoad()
    {
        SaveLoad_Tap.SetActive(true);
        Pause_Tap.SetActive(false);
    }

    public void OnClick_Option()
    {
        option.SetActive(true);
        Pause_Tap.SetActive(false);
    }

   
}
