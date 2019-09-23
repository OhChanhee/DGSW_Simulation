using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameResult
{
    public static void LoadResultScene(bool isWin, System.Action transformation)
    {
        SaveStat();

        transformation(); //스탯 변화

        SaveResult(isWin);

        SceneManager.LoadScene("Result", LoadSceneMode.Single);
    }

    public static void LoadResultScene(bool isWin, CharacterStat newStat)
    {

        SaveStat();

        CharacterManager.Get_instance().characterStat = newStat; //스탯 변화

        SaveResult(isWin);

        SceneManager.LoadScene("Result", LoadSceneMode.Single);
    }

    private static void SaveStat()
    {
        GameObject gObj = new GameObject("Holder");

        StatHolder holder = gObj.AddComponent(typeof(StatHolder)).GetComponent<StatHolder>();

        holder.oldStat = CharacterManager.Get_instance().characterStat.clone;

        UnityEngine.Object.DontDestroyOnLoad(holder); //스탯 저장
    }

    private static void SaveResult(bool isWin)
    {
        string result = isWin ? "Success" : "Failure";

        PlayerPrefs.SetString("MinigameResult", result); // 미니게임 성공여부
    }
}
