using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndingList : MonoBehaviour
{
    public GameObject contents;
    public VerticalLayoutGroup verticalGroup;
    List<Ending> endingList;

    // Start is called before the first frame update
    void Start()
    {
        InitEndingList();

        UpdateEndingList();

        float contentsHeight = 0f;
        foreach(Transform transform in contents.transform)
        {
            contentsHeight += (transform as RectTransform).rect.height;
            contentsHeight += verticalGroup.spacing;
        }

        Rect contentsRect = (contents.transform as RectTransform).rect;
        (contents.transform as RectTransform).sizeDelta = new Vector2(contentsRect.x, contentsHeight);
    }

    void InitEndingList()
    {
        endingList = new List<Ending>();
        List<Type> assemblyTypeList = new List<Type>(GetType().Assembly.GetTypes());

        assemblyTypeList = assemblyTypeList.FindAll((Type t) => 
        {
            return t.BaseType == typeof(Ending);
        });

        foreach(Type type in assemblyTypeList)
        {
            Ending instance = ScriptableObject.CreateInstance(type) as Ending;
            endingList.Add(instance);
        }
    }

    void UpdateEndingList()
    {
        foreach(Ending ending in endingList)
        {
            GameObject content = GameObject.Find(ending.GetType().Name);
            content.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (ending.CheckPossibility())
                {
                    UIEffect.Fade(GetComponent<CanvasGroup>(), 0f, 1f);
                    TaskManager.Delay(1f, () => ending.LoadEnding());
                }
            });
        }
    }
}
