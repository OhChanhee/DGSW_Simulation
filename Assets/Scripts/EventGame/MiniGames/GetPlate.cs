using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlate : MonoBehaviour
{
    Vector3 pos = new Vector3(0, 0, 0);

    void Start()
    {
        judgingEvent();
    }

    public void judgingEvent()
    {
        GameObject[] game = Resources.LoadAll<GameObject>("PlateGame");
        bringGame(game);
    }

    public void bringGame(GameObject[] game)
    {   
        foreach (GameObject i in game)
        {
            if (i.name == "A Main Camera")
            {
                pos = new Vector3(0, 0, -10);
            }
            else
            {
                pos = i.transform.position;
            }
            Instantiate(i, pos, Quaternion.identity);
        }
    }
}
