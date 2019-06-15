using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
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
            instance = (CharacterManager)FindObjectOfType(typeof(CharacterManager));
        }

        return instance;
    }

}
