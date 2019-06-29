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

    // 캐릭터의 스탯
    public int hp;
    public int sociability;
    public int intelligence;
    public int sensibility;
    public int charm;
    public int fatigue;
    public int stress;
    public int programming;
    public int music;
    public int design;
    public int exercise;
    public int creative;
    public int leadership;

    // 프로그래밍 스탯의 세부 스탯
    public int web;
    public int windows;
    public int mobile;
    public int embedded;
    public int server;
    public int game;
    public int programmingKnowledge;
    public int database;
    public int data_structure;

    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = CreateInstance<CharacterManager>();
        }

        return instance;
    }
}