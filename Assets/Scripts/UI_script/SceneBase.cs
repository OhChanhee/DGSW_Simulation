using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class SceneBase : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    protected Action endScene = () => { };
    protected float fadeInTime = 1f;
    protected float fadeOutTime = 1f;
    protected string nextScene = null;

    // Start is called before the first frame update
    protected void Start()
    {
        canvasGroup.alpha = 0f;
        UIEffect.Fade(canvasGroup, 1f ,fadeInTime);
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
}
