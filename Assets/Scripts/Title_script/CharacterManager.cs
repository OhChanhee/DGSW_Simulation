using UnityEngine;
using UnityEditor;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using Assets.Scripts.Utilities;

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
    public DateTime birthday;
    public int grade;
    public int season;
    public bool isCouple;
    public Gamedate curdate = new Gamedate();
    public Personality personality;
    public int Money;
    public CharacterStat characterStat = new CharacterStat();

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

    [Serializable]
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

