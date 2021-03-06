﻿using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using Assets.Scripts.Utilities;
using System.Reflection;

[Serializable]
public class CharacterManager 
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
    public BirthdayDate birthday = new BirthdayDate();
    public Major major = Major.공통과;
    public int grade = 3;
    public int season = 1;
    public bool hasTeam;
    public bool isCouple;
    public Gamedate curdate = new Gamedate();
    public Personality personality;
    public int Money;
    public CharacterStat _characterStat = new CharacterStat();
    public CharacterStat characterStat
    {
        get { return _characterStat; }

        set
        {
            PropertyInfo[] properties = typeof(CharacterStat).GetProperties();

            foreach(PropertyInfo property in properties)
            {
                if (property.SetMethod == null || Array.Exists(properties, (item) => { return (item.Name == "raw" + property.Name); })) continue;

                property.SetValue(characterStat, Math.Max(Math.Min((int)property.GetValue(value), MAX_STAT),0));
            }
        }
    }

    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = new CharacterManager();
        }

        return instance;
    }

    public void Save()
    {
        string filePath = "";
        if (playerName != null)
            filePath = Application.dataPath + "/" + playerName + ".bin";
        else
            filePath = Application.dataPath + "/테스트.bin";
        
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, this);
        stream.Close();
    }

    public CharacterManager Load()
    {
        string filePath;
        if (playerName != null)
            filePath = Application.dataPath + "/" + playerName + ".bin";
        else
            filePath = Application.dataPath + "/테스트.bin";

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(filePath, FileMode.Open);
        CharacterManager characterManager = formatter.Deserialize(stream) as CharacterManager;
        stream.Close();

        return characterManager;
    }
}

[Serializable]
public class BirthdayDate
{
    public int grade = 3;

    Gamedate _gamedate = new Gamedate();
    public Gamedate gamedate
    {
        get { return _gamedate; }
        set { _gamedate = value; }
    }
}

[Serializable]
public class Gamedate
{
    DateTime _dateTime = new DateTime();
    public DateTime dateTime
    {
        get { return _dateTime; }
        set { _dateTime = value; }
    }

    int _week = 1;
    public int week
    {
        get { return _week; }
        set
        {
            if (value > 4)
            {
                bool isDecember = (dateTime.Month == 12);

                if (isDecember) dateTime = new DateTime(dateTime.Year + 1, 1, 1);
                else
                {
                    if (dateTime.Month == 2 && _week > 2)
                    {
                        CharacterManager.Get_instance().grade++;
                    }

                    dateTime = new DateTime(dateTime.Year, dateTime.Month + 1, 1);
                }
            }
            _week = value > 4 || value < 1 ? value % 4 : value;
        }
    }
}