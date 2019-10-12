using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float startTime;
    public float duration;

    void Start()
    {
        canvasGroup.alpha = 0f;

        StartCoroutine(TaskManager.Delay(startTime, () => StartCoroutine(UIEffect.Fade(canvasGroup, 1f, duration))));
    }
}
