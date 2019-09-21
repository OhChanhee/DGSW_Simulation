using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameResult
{
    public static void LoadResultScene(GameObject obj,
                                       bool isWin,
                                       System.Action transformation)
    {
        string result = isWin ? "Success" : "Failure";

        SaveStat(obj);

        transformation(); //스탯 변화

        PlayerPrefs.SetString("MinigameResult", result); // 미니게임 성공여부

        SceneManager.LoadScene("Result");
    }

    public static void LoadResultScene(GameObject obj,
                                       bool isWin,
                                       CharacterStat newStat)
    {
        string result = isWin ? "Success" : "Failure";

        SaveStat(obj);

        CharacterManager.Get_instance().characterStat = newStat; //스탯 변화

        PlayerPrefs.SetString("MinigameResult", result); // 미니게임 성공여부

        SceneManager.LoadScene("Result");
    }

    private static void SaveStat(GameObject obj)
    {

        GameObject gObj = SceneManager.GetActiveScene().GetRootGameObjects()[1];
        gObj.AddComponent(typeof(StatHolder));
        StatHolder holder = gObj.GetComponent<StatHolder>();

        holder.oldStat = CharacterManager.Get_instance().characterStat.clone;

        UnityEngine.Object.DontDestroyOnLoad(holder); //스탯 저장
    }
}
