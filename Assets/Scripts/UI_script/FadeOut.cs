using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float startTime;
    public float duration;
    public string nextScene;

    void Start()
    {
        StartCoroutine(TaskManager.Delay(startTime, () => UIEffect.Fade(canvasGroup, 0f, duration)));
        StartCoroutine(TaskManager.Delay(startTime + duration, () => SceneManager.LoadScene(nextScene)));
    }
}
