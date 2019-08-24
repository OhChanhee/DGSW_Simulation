﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discriminate : MonoBehaviour
{
    Vector3 pos = new Vector3(0, 0, 0);

    void Start()
    {
        judgingEvent();
    }

    public void judgingEvent()
    {
        switch (PlayerPrefs.GetInt("whatEvent"))
        {
            case 126:
                GameObject[] game = Resources.LoadAll<GameObject>("MiniGame3");
                bringGame(game);
                break;
            case 129:
                game = Resources.LoadAll<GameObject>("MiniGame1");
                bringGame(game);
                break;
            case 131:
                game = Resources.LoadAll<GameObject>("MiniGame2");
                bringGame(game);
                break;
            case 127:
                game = Resources.LoadAll<GameObject>("MiniGame_hideClass");
                bringGame(game);
                break;
            default:
                break;
        }
        Debug.Log(PlayerPrefs.GetInt("whatEvent"));
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
                pos = new Vector3(0, 0, 0);
            }
            Instantiate(i, pos, Quaternion.identity);
        }
    }
}
