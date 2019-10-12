using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Utilities;
using System;

public class UIEffect
{
    public static Coroutine Fade(CanvasGroup group, float alpha, float duration, Action onEndCoroutine = null)
    {
        return StaticObject.instance.StartCoroutine(_Fade(group, alpha, duration, onEndCoroutine));
    }

    private static IEnumerator _Fade(CanvasGroup group, float alpha, float duration, Action onEndCoroutine)
    {
        float initialAlpha = group.alpha;
        float startTime = Time.time;

        for (; Time.time <= startTime + duration;)
        {
            group.alpha = MapRange(Time.time, startTime, startTime + duration, initialAlpha, alpha);

            yield return new WaitForSeconds(0.05f);
        }

        TaskManager.Callback(onEndCoroutine);
    }

    public static Coroutine ShowEachChar(Text text, float delay, Action onEndCoroutine = null)
    {
        return StaticObject.instance.StartCoroutine(_ShowEachChar(text, delay, onEndCoroutine));
    }

    private static IEnumerator _ShowEachChar(Text text, float delay, Action onEndCoroutine)
    {
        string content = text.text;
        text.text = "";

        for (int i = 1; !text.text.Equals(content); i++)
        {
            text.text = content.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }

        TaskManager.Callback(onEndCoroutine);
    }

    private static float MapRange(float value, float inRangeA, float inRangeB, float outRangeA, float outRangeB)
    {
        value = Mathf.Clamp(value, Mathf.Min(inRangeA, inRangeB), Mathf.Max(inRangeA, inRangeB));

        float scale = (value - inRangeA) / (inRangeB - inRangeA);

        return scale * (outRangeB - outRangeA) + outRangeA;
    }
}
