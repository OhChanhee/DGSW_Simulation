using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEvent : MonoBehaviour
{
    List<Event> eventList;

    // Start is called before the first frame update
    void Start()
    {
        InitEventList();

        CallEvent();
    }

    void InitEventList()
    {
        eventList = new List<Event>();

        List<Type> assemblyTypeList = new List<Type>(typeof(Event).Assembly.GetTypes()).FindAll((Type type) => 
        {
            return (type.BaseType == typeof(Event));
        });

        foreach(Type type in assemblyTypeList)
        {
            Event instance = ScriptableObject.CreateInstance(type) as Event;

            eventList.Add(instance);
        }
    }

    void CallEvent()
    {
        if (eventList.Count == 0) return;

        foreach(Event ev in eventList)
        {
            if (ev.HasEvent())
            {
                SceneManager.LoadScene(ev.GetType().Name);
            }
        }
    }
}
