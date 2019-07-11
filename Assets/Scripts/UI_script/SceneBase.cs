using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class SceneBase : MonoBehaviour
{
    public Canvas canvas;
    protected Action endScene = () => { };
    protected float fadeInTime = 1f;
    protected float fadeOutTime = 1f;
    protected string nextScene = null;

    // Start is called before the first frame update
    protected void Start()
    {
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
        StartCoroutine(UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 1f ,fadeInTime));
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
            StartCoroutine(TaskManager.Delay(fadeOutTime, () =>
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
            }));
        }
        StartCoroutine(UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 0f, fadeOutTime));
    }
}
