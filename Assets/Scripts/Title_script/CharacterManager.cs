using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class CharacterManager : ScriptableObject 
{
    /*
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
    */
    const int MAX_HEALTH = 100;
    const int MAX_STAT = 1000;

    public static CharacterManager instance;

    // 캐릭터의 정보
    public string playerName;
    public Gender gender;
    public DateTime birthday;
    public bool isCouple;
    public Gamedate curdate = new Gamedate();
    public Personality personality;
    public int Money;
    public CharacterStat characterStat = new CharacterStat();

    

    public static CharacterManager operator+(CharacterManager param1, CharacterManager param2)
    {
        CharacterManager result = new CharacterManager();
        CharacterStat resultStat = result.characterStat;
        CharacterStat param1Stat = param1.characterStat;
        CharacterStat param2Stat = param2.characterStat;

        resultStat.hp = param1Stat.hp + param2Stat.hp;
        resultStat.sociability = param1Stat.sociability + param2Stat.sociability;
        resultStat.intelligence = param1Stat.intelligence + param2Stat.intelligence;
        resultStat.sensibility = param1Stat.sensibility + param2Stat.sensibility;
        resultStat.charm = param1Stat.charm + param2Stat.charm;
        resultStat.fatigue = param1Stat.fatigue + param2Stat.fatigue;
        resultStat.stress = param1Stat.stress + param2Stat.stress;
        resultStat.programming = param1Stat.programming + param2Stat.programming;
        resultStat.music = param1Stat.music + param2Stat.music;
        resultStat.design = param1Stat.design + param2Stat.design;
        resultStat.exercise = param1Stat.exercise + param2Stat.exercise;
        resultStat.creative = param1Stat.creative + param2Stat.creative;
        resultStat.leadership = param1Stat.leadership + param2Stat.leadership;
        resultStat.rewardPoint = param1Stat.rewardPoint + param2Stat.rewardPoint;
        resultStat.web = param1Stat.web + param2Stat.web;
        resultStat.windows = param1Stat.windows + param2Stat.windows;
        resultStat.mobile = param1Stat.mobile + param2Stat.mobile;
        resultStat.embedded = param1Stat.embedded + param2Stat.embedded;
        resultStat.server = param1Stat.server + param2Stat.server;
        resultStat.game = param1Stat.game + param2Stat.game;
        resultStat.database = param1Stat.database + param2Stat.database;
        resultStat.dataStructure = param1Stat.dataStructure + param2Stat.dataStructure;

        return result;
    }

    

    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = CreateInstance<CharacterManager>();
        }

        return instance;
    }

    public class Gamedate
    {
        DateTime _dateTime = new DateTime();
        public System.DateTime dateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        int _week = 1;
        public int week
        {
            get { return _week; }
            set { _week = value > 4 || value < 1 ? value % 4 + 1 : value; }
        }
    }
}

