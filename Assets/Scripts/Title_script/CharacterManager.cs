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
    int hp;
    int sociability;
    int intelligence;
    int sensibility;
    int charm;
    int fatigue;
    int stress;
    int programming;
    int music;
    int design;
    int exercise;
    int creative;
    int leadership;

    // 프로그래밍 스탯의 세부 스탯
    int web;
    int windows;
    int mobile;
    int embedded;
    int server;
    int game;
    int programmingKnowledge;
    int database;
    int data_structure;

    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = CreateInstance<CharacterManager>();
        }

        return instance;
    }
}