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

    // 캐릭터의 스탯
    int _hp = 100;
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = Math.Min(value, MAX_HEALTH);
        }
    }

    int _sociability=50;
    public int sociability
    {
        get
        {
            return _sociability;
        }
        set
        {
            _sociability = Math.Min(value, MAX_STAT);
        }
    }

    int _intelligence=50;
    public int intelligence
    {
        get
        {
            return _intelligence;
        }
        set
        {
            _intelligence = Math.Min(value, MAX_STAT);
        }
    }

    int _sensibility=50;
    public int sensibility
    {
        get
        {
            return _sensibility;
        }
        set
        {
            _sensibility = Math.Min(value, MAX_STAT);
        }
    }

    int _charm =50;
    public int charm
    {
        get
        {
            return _charm;
        }
        set
        {
            _charm = Math.Min(value, MAX_STAT);
        }
    }

    int _fatigue =50;
    public int fatigue
    {
        get
        {
            return _fatigue;
        }
        set
        {
            _fatigue = Math.Min(value, MAX_HEALTH);
        }
    }

    int _stress =0;
    public int stress
    {
        get
        {
            return _stress;
        }
        set
        {
            _stress = Math.Min(value, MAX_HEALTH);
        }
    }

    int _programming =50;
    public int programming
    {
        get
        {
            return _programming;
        }
        set
        {
            _programming = Math.Min(value, MAX_STAT);
        }
    }

    int _music =50;
    public int music
    {
        get
        {
            return _music;
        }
        set
        {
            _music = Math.Min(value, MAX_STAT);
        }
    }

    int _design =50;
    public int design
    {
        get
        {
            return _design;
        }
        set
        {
            _design = Math.Min(value, MAX_STAT);
        }
    }

    int _exercise =50;
    public int exercise
    {
        get
        {
            return _exercise;
        }
        set
        {
            _exercise = Math.Min(value, MAX_STAT);
        }
    }

    int _creative =50;
    public int creative
    {
        get
        {
            return _creative;
        }
        set
        {
            _creative = Math.Min(value, MAX_STAT);
        }
    }

    int _leadership =50;
    public int leadership
    {
        get
        {
            return _leadership;
        }
        set
        {
            _leadership = Math.Min(value, MAX_STAT);
        }
    }

    int _rewardPoint =0;
    public int rewardPoint
    {
        get
        {
            return _rewardPoint;
        }
        set
        {
            _rewardPoint = value;
        }
    }


    // 프로그래밍 스탯의 세부 스탯
    int _web =0;
    public int web
    {
        get
        {
            return _web;
        }
        set
        {
            _web = Math.Min(value, MAX_STAT);
        }
    }


    int _windows =0;
    public int windows
    {
        get
        {
            return _windows;
        }
        set
        {
            _windows = Math.Min(value, MAX_STAT);
        }
    }

    int _mobile =0;
    public int mobile
    {
        get
        {
            return _mobile;
        }
        set
        {
            _mobile = Math.Min(value, MAX_STAT);
        }
    }

    int _embedded =0;
    public int embedded
    {
        get
        {
            return _embedded;
        }
        set
        {
            _embedded = Math.Min(value, MAX_STAT);
        }
    }

    int _server =0;
    public int server
    {
        get
        {
            return _server;
        }
        set
        {
            _server = Math.Min(value, MAX_STAT);
        }
    }

    int _game =0;
    public int game
    {
        get
        {
            return _game;
        }
        set
        {
            _game = Math.Min(value, MAX_STAT);
        }
    }

    int _programmingKnowledge =0;
    public int programmingKnowledge
    {
        get
        {
            return _programmingKnowledge;
        }
        set
        {
            _programmingKnowledge = Math.Min(value, MAX_STAT);
        }
    }

    int _database =0;
    public int database
    {
        get
        {
            return _database;
        }
        set
        {
            _database = Math.Min(value, MAX_STAT);
        }
    }

    int _dataStructure =0;
    public int dataStructure
    {
        get
        {
            return _dataStructure;
        }
        set
        {
            _dataStructure = Math.Min(value, MAX_STAT);
        }
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
        DateTime _dateTime;

        public System.DateTime dateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }

        int _week = 1;
        public int week
        {
            get
            {
                return _week;
            }
            set
            {
                _week = value > 4 || value < 1 ? value % 4 + 1 : value;
            }
        }
    }

}

