using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaiser : MonoBehaviour
{
    public Camera cam;
    public RaycastHit hit;
    public Text ramentText;
    public Text chopText;
    public Text watertText;
    public Text helpText;
    private float maxDistance = 6;
    public bool isRamen = false;
    public bool isChop = false;
    public bool isWater = false;
    MoveTeacher mt;
    EnterEnding eed;

    void Start()
    {
        mt = GameObject.Find("MasterTeacher").GetComponent<MoveTeacher>();
        eed = GameObject.Find("EndingArea").GetComponent<EnterEnding>();
    }

    void Update()
    {
        TakeThing();
        if(isRamen == true && isChop == true && isWater == true && eed.isEnter == true)
        {
            mt.isEnd = true;
            mt.isWin = true;
        }
    }

    public void TakeThing()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance)) {
            if(hit.transform.name == "door")
            {
                if (hit.transform.GetComponent<ControllDoor>().rock == false)
                {
                    helpText.text = "문 열기";
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.GetComponent<ControllDoor>().ChangeDoor();
                    }
                }
            } else if(hit.transform.name == "ramen")
            {
                helpText.text = "라면 줍기";
                if (Input.GetMouseButtonDown(0))
                {
                    ramentText.text = "라면: O";
                    isRamen = true;
                }
            } else if(hit.transform.name == "chopsticks")
            {
                helpText.text = "젓가락 줍기";
                if (Input.GetMouseButtonDown(0))
                {
                    chopText.text = "젓가락: O";
                    isChop = true;
                }
            } else if(hit.transform.name == "mob_WaterCooler_A")
            {
                helpText.text = "뜨거운 물 얻기";
                if (Input.GetMouseButtonDown(0))
                {
                    watertText.text = "물: O";
                    isWater = true;
                }
            }
        } else
        {
            helpText.text = "";
        }
    }
}
