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

    public static Coroutine ShowEachChar(Text textComponent, float delay, Action onEndCoroutine = null)
    {
        return StaticObject.instance.StartCoroutine(_ShowEachChar(textComponent, delay, onEndCoroutine));
    }

    private static IEnumerator _ShowEachChar(Text textComponent, float delay, Action onEndCoroutine)
    {
        string content = textComponent.text;
        textComponent.text = "";

        for (int i = 1; !textComponent.text.Equals(content); i++)
        {
            textComponent.text = content.Substring(0, i);
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

    public static Coroutine DotRepeat(Text textComponent, float interval, int max, float duration = -1f, Action onEndCoroutine = null)
    {
        return StaticObject.instance.StartCoroutine(_DotRepeat(textComponent, interval, max, duration, onEndCoroutine));
    }

    private static IEnumerator _DotRepeat(Text textComponent, float interval, int max, float duration = -1, Action onEndCoroutine = null)
    {
        string dots;
        string textContent = textComponent.text;
        float endTime = Time.time - duration;

        bool isInfinity = duration < 0f;

        while (isInfinity || Time.time < endTime)
        {
            dots = "";
            for(int i = 0; i < GetRangeByTime(interval, max); i++)
            {
                dots += ".";
                textComponent.text = textContent + dots;
            }

            yield return new WaitForSeconds(interval);
        }

        textComponent.text = textContent;

        TaskManager.Callback(onEndCoroutine);
    }

    private static int GetRangeByTime(float unit, int max)
    {
        int valueByTime = (int)(Time.time / unit);
        return valueByTime % (max + 1);
    }
}
