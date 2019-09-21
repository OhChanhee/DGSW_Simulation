using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discriminate_Line : MonoBehaviour
{
    Vector3 pos = new Vector3(0, 0, 0);

    void Start()
    {
        judgingEvent();
    }

    public void judgingEvent()
    {
        /*switch (PlayerPrefs.GetInt("whatEvent"))
        {*/
        /*case 132:
            GameObject[] game = Resources.LoadAll<GameObject>("MiniGame3");
            bringGame(game);
            break;*/
        /*case 136:
            GameObject[] game = Resources.LoadAll<GameObject>("MiniGame1");
            bringGame(game);
            break;
        case 138:
            game = Resources.LoadAll<GameObject>("MiniGame2");
            bringGame(game);
            break;
        case 133:
            game = Resources.LoadAll<GameObject>("MiniGame_hideClass");
            bringGame(game);
            break;
        case 137:
            game = Resources.LoadAll<GameObject>("Minigame_RelayRace");
            bringGame(game);
            break;
        default:
            break;
    }*/
        //Debug.Log(PlayerPrefs.GetInt("whatEvent"));
        GameObject[] game = Resources.LoadAll<GameObject>("MiniGame1");
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
