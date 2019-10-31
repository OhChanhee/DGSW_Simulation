using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

public abstract class EventScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    protected string nextScene = "Main";
    List<Dictionary<string, object>> fixedEventData;

    private void Awake()
    {
        fixedEventData = CSVReader.Read("csvFolder/FixedEvent");
    }

    protected void EndScene()
    {
        SceneManager.LoadScene(nextScene);
    }
    
    protected void AddStat(string eventName)
    {
        if (fixedEventData == null) return;

        for (int i = 0; i < fixedEventData.Count; i++)
        {
            if (fixedEventData[i]["item_var_name"].ToString() == (eventName + "Ev"))
            {
                CharacterManager.Get_instance().characterStat += GetChangement(i);
            }
        }
    }

    protected CharacterStat GetChangement(int idx)
    {
        CharacterStat result = CharacterStat.zero;
        Type type = typeof(CharacterStat);

        foreach (PropertyInfo property in type.GetProperties())
        {
            string propertyName = property.Name;
            if (propertyName.StartsWith("raw") || property.SetMethod == null)
            {
                continue;
            }

            string value = fixedEventData[idx][propertyName].ToString();

            if (value.ToString().Length == 0) continue;

            int integerValue = int.Parse(value);

            property.SetValue(result, integerValue);
        }

        return result;
    }
}
