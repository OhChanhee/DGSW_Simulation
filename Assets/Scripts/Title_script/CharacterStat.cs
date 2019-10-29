using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class CharacterStat
{
    public static int MAX_HEALTH = 100;
    public static int MAX_STAT = 1000;

    // 캐릭터의 스탯
    int _hp = 1000;
    public int hp
    {
        get { return _hp * MAX_HEALTH / MAX_STAT; }
        set
        {
            _hp = Math.Min(value * MAX_STAT / MAX_HEALTH, MAX_STAT);
        }
    }

    public int rawHp
    {
        get { return _hp; }
        set
        {
            _hp = Math.Min(value, MAX_STAT);
        }
    }

    int _sociability = 50;
    public int sociability
    {
        get { return _sociability; }
        set { _sociability = Math.Min(value, MAX_STAT); }
    }

    int _intelligence = 50;
    public int intelligence
    {
        get { return _intelligence; }
        set { _intelligence = Math.Min(value, MAX_STAT); }
    }

    int _sensibility = 50;
    public int sensibility
    {
        get { return _sensibility; }
        set { _sensibility = Math.Min(value, MAX_STAT); }
    }

    int _charm = 50;
    public int charm
    {
        get { return _charm; }
        set { _charm = Math.Min(value, MAX_STAT); }
    }

    int _fatigue = 500;
    public int fatigue
    {
        get { return _fatigue * MAX_HEALTH / MAX_STAT; }
        set { _fatigue = Math.Min(value * MAX_STAT / MAX_HEALTH, MAX_STAT); }
    }

    public int rawFatigue
    {
        get { return _fatigue; }
        set { _fatigue = Math.Min(value, MAX_STAT); }
    }

    int _stress = 0;
    public int stress
    {
        get { return _stress * MAX_HEALTH / MAX_STAT; }
        set { _stress = Math.Min(value * MAX_STAT / MAX_HEALTH, MAX_STAT); }
    }

    public int rawStress
    {
        get { return _stress; }
        set { _stress = Math.Min(value, MAX_STAT); }
    }

    public int programming
    {
        get { return Mathf.Max(web, operSystem, mobile, embedded, server, game);}
    }

    int _music = 50;
    public int music
    {
        get { return _music; }
        set { _music = Math.Min(value, MAX_STAT); }
    }

    int _design = 50;
    public int design
    {
        get { return _design; }
        set { _design = Math.Min(value, MAX_STAT); }
    }

    int _exercise = 50;
    public int exercise
    {
        get { return _exercise; }
        set { _exercise = Math.Min(value, MAX_STAT); }
    }

    int _creative = 50;
    public int creative
    {
        get { return _creative; }
        set { _creative = Math.Min(value, MAX_STAT); }
    }

    int _leadership = 50;
    public int leadership
    {
        get { return _leadership; }
        set { _leadership = Math.Min(value, MAX_STAT); }
    }

    int _rewardPoint = 0;
    public int rewardPoint
    {
        get { return _rewardPoint; }
        set { _rewardPoint = value; }
    }

    // 프로그래밍 스탯의 세부 스탯
    int _web = 0;
    public int web
    {
        get { return _web; }
        set { _web = Math.Min(value, MAX_STAT); }
    }

    int _operSystem = 0;
    public int operSystem
    {
        get { return _operSystem; }
        set { _operSystem = Math.Min(value, MAX_STAT); }
    }

    int _mobile = 0;
    public int mobile
    {
        get { return _mobile; }
        set { _mobile = Math.Min(value, MAX_STAT); }
    }

    int _embedded = 0;
    public int embedded
    {
        get { return _embedded; }
        set { _embedded = Math.Min(value, MAX_STAT); }
    }

    int _server = 0;
    public int server
    {
        get { return _server; }
        set { _server = Math.Min(value, MAX_STAT); }
    }

    int _game = 0;
    public int game
    {
        get { return _game; }
        set { _game = Math.Min(value, MAX_STAT); }
    }

    int _database = 0;
    public int database
    {
        get { return _database; }
        set { _database = Math.Min(value, MAX_STAT); }
    }

    int _dataStructure = 0;
    public int dataStructure
    {
        get { return _dataStructure; }
        set { _dataStructure = Math.Min(value, MAX_STAT); }
    }

    public int programmingKnowledge
    {
        get
        {
            int result = programming / 2 + (dataStructure + database) / 2;

            return result;
        }
    }

    public static CharacterStat zero
    {
        get
        {
            CharacterStat result = new CharacterStat();

            PropertyInfo[] properties = typeof(CharacterStat).GetProperties();

            foreach(PropertyInfo property in properties)
            {
                if(property.SetMethod == null)
                {
                    continue;
                }

                property.SetValue(result, 0);
            }

            return result;
        }
    }

    public CharacterStat clone
    {
        get
        {
            CharacterStat clone = new CharacterStat();

            PropertyInfo[] properties = GetType().GetProperties();

            foreach(PropertyInfo property in properties)
            {
                if (property.SetMethod == null) continue;

                property.SetValue(clone, property.GetValue(this));
            }

            return clone;
        }
    }

    public static CharacterStat operator +(CharacterStat param1, CharacterStat param2)
    {
        CharacterStat result = new CharacterStat();

        PropertyInfo[] properties = result.GetType().GetProperties();

        foreach (PropertyInfo property in properties)
        {
            if (property.SetMethod == null) continue;

            int sum = (int)property.GetValue(param1) + (int)property.GetValue(param2);
            property.SetValue(result, sum);
        }

        return result;
    }

    public float GetStatRatio(string statName)
    {
        int value = (int)GetType().GetProperty(statName).GetValue(this);
        return value / (float)MAX_STAT;
    }
}
