using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGm_PlateManager : MonoBehaviour
{

    public GameObject[] plates_array;
    [HideInInspector]
    public List<GameObject> plateList = new List<GameObject>();
    private SpriteRenderer spriterenderer;
    private int delayTIme = 0;
    private bool isDelay = false;
    private bool isPlayAi = true;
    [HideInInspector]
    public bool isEnded = false;
    private float time;
    private int red_count;
    private int blue_count;
    private Text time_Text;
    private Text red_Text;
    private Text blue_Text;

    void Start()
    {
        time = 15;
        time_Text = GameObject.Find("time_Text").GetComponent<Text>();
        red_Text = GameObject.Find("plateRedNumber").GetComponent<Text>();
        blue_Text = GameObject.Find("plateBlueNumber").GetComponent<Text>();
        foreach(GameObject i in plates_array)
        {
            plateList.Add(i);
        }
    }

    void FixedUpdate()
    {
        timing();
        if(isDelay == true)
        {
            isPlayAi = false;
            delayTIme += 1;
            if(delayTIme == 30)
            {
                isDelay = false;
                isPlayAi = true; 
                delayTIme = 0;
            }
        }
    }

    void Update()
    {
        if(judging_game() == false)
        {
            if (random() == true && isPlayAi == true)
            {
                StartCoroutine(changeColor_Ai());
            }
            else
            {
                StopCoroutine(changeColor_Ai());
            }
        }

        foreach(GameObject i in plateList)
        {
            if(i.tag == "red")
            {
                red_count++;
                red_Text.text = "빨강: " + red_count.ToString();
            }
            else if(i.tag == "blue")
            {
                blue_count++;
                blue_Text.text = "파랑: " + blue_count.ToString();
            }
        }
    }

    IEnumerator changeColor_Ai()
    {
        GameObject thePlate = plateList[random_Plate()];
        if (thePlate.tag == "red")
        {
            spriterenderer = thePlate.GetComponent<SpriteRenderer>();
            spriterenderer.color = new Color(0, 0, 255, 255);
            thePlate.tag = "blue";
            isDelay = true;
        }
        StopCoroutine(changeColor_Ai());
        yield return null;
    }

    public void timing()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            time_Text.text = $"{time:N1}";
        }
        else
        {
            time = 0;
        }
    }

    public bool judging_game()
    {
        if (time <= 0)
        {
            Debug.Log("게임 끝!");
            isEnded = true;
            return true;
        }
        return false;
    }

    public bool random()
    {
        int rand = Random.Range(0, 4);
        if(rand == 0 || rand == 1)
        {
            return true;
        }
        return false;
    }

    public int random_Plate()
    {
        return Random.Range(0, 32);
    }
}
