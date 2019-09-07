using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doGame : MonoBehaviour
{
    teacherControl TCtrl;
    public bool isPlus = false;

    void Start()
    {
        TCtrl = GameObject.Find("professor(Clone)").GetComponent<teacherControl>();
    }

    void Update()
    {
        if(TCtrl.isFinish == false)
        {
            doGaming();
        }
        else
        {
            Debug.Log("끝!");
        }
    }

    public void doGaming()
    {
        if (Input.GetKey(KeyCode.Space)) {
            isPlus = true;
            gaming();
        }
        else
        {
            isPlus = false;
        }
    }

    public void gaming()
    {
        //학생이 게임하는 이벤트 발생
    }

    public void studying()
    {
        //학생이 공부하는 이벤트 발생
    }
}
