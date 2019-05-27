using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGm_LineManager : MonoBehaviour
{
    public GameObject line;
    private Transform line_Transform;
    private bool clickLeft_Limit = true;
    private bool clickRight_Limit = true;
    private float time;
    private Text time_Text;

    void Start()
    {
        line_Transform = line.GetComponent<Transform>();
        time_Text = GameObject.Find("time_Text").GetComponent<Text>();
        time = 30;
    }

    void FixedUpdate()
    {
        timing();
    }

    void Update()
    {
        proceed_Game();
    }

    public void proceed_Game()
    {
        if (judging_game() == false)
        {
            Debug.Log(judging_game());

            if (Input.GetKeyUp(KeyCode.LeftArrow) && clickLeft_Limit == true)
            {
                clickLeft_Limit = false;
                clickRight_Limit = true;
                pullingLine_ToPlayer();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) && clickRight_Limit == true)
            {
                clickRight_Limit = false;
                clickLeft_Limit = true;
                pullingLine_ToPlayer();
            }
            pullingLine_ToAi();
        }
    }

    public void pullingLine_ToPlayer()
    {
        line_Transform.position = new Vector3(line_Transform.position.x - 0.15f, 0, -1);
    }

    public void pullingLine_ToAi()
    {
        if(judging_pullingAi() == true)
        {
            line_Transform.position = new Vector3(line_Transform.position.x + 0.1f, 0, -1);
        }
    }

    public bool judging_pullingAi()
    {
        int rand = Random.Range(0, 5);
        if(rand == 1 || rand == 2)
        {
            return true;
        }
        return false;
    }

    public bool judging_game()
    {
        if(line_Transform.position.x >= 9)
        {
            Debug.Log("Ai 승!");
            return true;
        }
        else if(line_Transform.position.x <= -9)
        {
            Debug.Log("플레이어 승!");
            return true;
        }
        else if(time <= 0)
        {
            Debug.Log("게임 끝!");
            if(line_Transform.position.x <= 0 && line_Transform.position.x > -9)
            {
                Debug.Log("타임오버 플레이어 승!");
            }
            else if (line_Transform.position.x >= 0 && line_Transform.position.x < 9)
            {
                Debug.Log("타임오버 Ai 승!");
            }
            return true;
        }
        return false;
    }

    public void timing()
    {
        if (time >= 0 && judging_game() == false)
        {
            time -= Time.deltaTime;
            time_Text.text = $"{time:N1}";
        }
        else
        {
            time = 0;
        }
    }
}
