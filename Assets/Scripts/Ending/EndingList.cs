using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EndingList : MonoBehaviour
{
    List<IEnding> endingList;

    // Start is called before the first frame update
    void Start()
    {
        InitEndingList();

        ShowEndingList();
    }

    void InitEndingList()
    {
        endingList = new List<IEnding>();
        List<Type> assemblyTypeList = new List<Type>(GetType().Assembly.GetTypes());

        assemblyTypeList = assemblyTypeList.FindAll((Type t) => 
        {
            return t.GetInterface("IEnding") != null;
        });

        foreach(Type type in assemblyTypeList)
        {
            Debug.Log(type.Name);
        }
        
    }

    void ShowEndingList()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
