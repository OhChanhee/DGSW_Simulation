using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

public abstract class SceneBase : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    protected Action endScene = () => { };
    protected float fadeInTime = 1f;
    protected float fadeOutTime = 1f;
    protected string nextScene = null;
    protected List<Dictionary<string, object>> data;

    // Start is called before the first frame update
    protected void Start()
    {
        canvasGroup.alpha = 0f;
        UIEffect.Fade(canvasGroup, 1f ,fadeInTime);

        data = CSVReader.Read("csvFolder/Event");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void EndScene()
    {
        endScene();

        if(nextScene != null)
        {
            TaskManager.Delay(fadeOutTime, () => SceneManager.LoadScene(nextScene, LoadSceneMode.Single));
        }

        UIEffect.Fade(canvasGroup, 0f, fadeOutTime);
    }

    protected void AddStat(string eventName)
    {
        if (data == null) return;

        for (int i = 0; i < data.Count; i++)
        {
            if (data[i]["item_var_name"].ToString() == (eventName + "Ev"))
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

            string value = data[idx][propertyName].ToString();

            if (value.ToString().Length == 0) continue;

            int integerValue = int.Parse(value);

            property.SetValue(result, integerValue);
        }

        return result;
    }
}
