using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEffect
{
    public delegate void Method();

    public static IEnumerator Fade(CanvasGroup group, float alpha, float duration)
    {
        float initialAlpha = group.alpha;
        float startTime = Time.time;

        for(; Time.time <= startTime + duration;)
        {
            group.alpha = MapRange(Time.time, startTime, startTime + duration, initialAlpha, alpha);

            yield return new WaitForSeconds(0.05f);
            
        }
    }

    

    public static IEnumerator ShowEachChar(Text text, float delay)
    {
        string content = text.text;
        text.text = "";

        for(int i = 1; !text.text.Equals(content); i++)
        {
            text.text = content.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    private static float MapRange(float value, float inRangeA, float inRangeB, float outRangeA, float outRangeB)
    {
        value = Mathf.Clamp(value, Mathf.Min(inRangeA, inRangeB), Mathf.Max(inRangeA, inRangeB));

        float scale = (value - inRangeA) / (inRangeB - inRangeA);

        return scale * (outRangeB - outRangeA) + outRangeA;
    }
}
