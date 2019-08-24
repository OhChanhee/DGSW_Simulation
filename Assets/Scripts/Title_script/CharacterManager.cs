using UnityEngine;
using UnityEditor;
using System;

public class CharacterManager : ScriptableObject
{
    /*
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }
    */

    public static CharacterManager instance;

    // 캐릭터의 정보
    public string playerName;
    public Gender gender;
    public DateTime birthday;
    public bool isCouple;
    public Gamedate curdate;
    public Personality personality;
    public int Money;

    // 캐릭터의 스탯
    public int hp=100;
    public int sociability=50;
    public int intelligence=50;
    public int sensibility=50;
    public int charm=50;
    public int fatigue=50;
    public int stress=0;
    public int programming=50;
    public int music=50;
    public int design=50;
    public int exercise=50;
    public int creative=50;
    public int leadership=50;
    public int rewardPoint=0;

    // 프로그래밍 스탯의 세부 스탯
    public int web=0;
    public int windows=0;
    public int mobile=0;
    public int embedded=0;
    public int server=0;
    public int game=0;
    public int programmingKnowledge=0;
    public int database=0;
    public int data_structure=0;

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
        public System.DateTime dateTime;

        public int week;
    }

}

