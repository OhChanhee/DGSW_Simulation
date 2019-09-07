using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacherControl : MonoBehaviour
{
    private float rand;
    private bool isBack = false; // false면 학생보고 있고 true면 칠판보고 있음
    private bool isRand = true;
    private bool isSpin = false;
    public bool isFinish = false;
    private Transform teacherTrans;

    void Start()
    {
        teacherTrans = GameObject.Find("professor(Clone)").GetComponent<Transform>();
    }

    void Update()
    {
        if (isFinish == false)
        {
            teacherAi();
        }
        else
        {
            Debug.Log("끝");
        }
    }

    public void teacherAi()
    {
        if(isRand == true)
        {
            makeRandom();
        }
        if(isBack == false && rand > 0.0f)
        {
            isRand = false;
            Debug.Log("학생보고잇음");
            subtractTime();
            if (rand <= 0.0f)
            {
                isSpin = false;
                isBack = true;
                Debug.Log("rand 0");
                randomReset();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                isFinish = true;
            }
        }
        else if(isBack == true && rand > 0.0f)
        {
            Debug.Log("칠판보고잇음");
            isRand = false;
            subtractTime();
            if (rand <= 0.0f)
            {
                isSpin = false;
                isBack = false;
                Debug.Log("rand 0");
                randomReset();
            }
        }
    }

    private void spinTeacher()
    {
        teacherTrans.eulerAngles = new Vector2(0, 200f * Time.deltaTime);
        Debug.Log("spin");
        //isSpin = true;
    }

    private void randomReset()
    {
        if(isSpin == false)
        {
            spinTeacher();
            Debug.Log("isSpinFALSE");
            rand = 0f;
            isRand = true;
        }
        
    }

    private void subtractTime()
    {
        rand -= Time.deltaTime * 1;
        //Debug.Log("subtractRand" + rand);
    }

    private void makeRandom()
    {
        isRand = false;
        rand = Random.Range(0.5f, 7.0f);
        //Debug.Log("makeRand" + rand);
    }
}
