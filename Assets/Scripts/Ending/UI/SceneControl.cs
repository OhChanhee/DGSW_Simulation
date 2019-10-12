using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public RawImage background;
    public Texture2D[] images;
    public Text textComponent;
    public float showCharInterval;
    public CanvasGroup canvasGroup;
    string[] contents;

    // Start is called before the first frame update
    void Start()
    {
        contents = textComponent.text.Split('|');

        StartCoroutine(ShowContents(()=>
        {
            StartCoroutine(UIEffect.Fade(canvasGroup, 0f, 1f));
            StartCoroutine(TaskManager.Delay(1f, () => SceneManager.LoadScene("EndingCredit")));
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowContents(Action onEndContents)
    {
        canvasGroup.alpha = 0f;

        for (int i = 0; i < contents.Length; i++)
        {
            float loopStartTime = Time.time;

            InitContent(i);

            Coroutine fadeIn = StartCoroutine(UIEffect.Fade(canvasGroup, 1f, 1f));

            Coroutine showEachChar = StartCoroutine(TaskManager.Delay(1f, () =>
            {
                textComponent.text = contents[i];
                StartCoroutine(UIEffect.ShowEachChar(textComponent, showCharInterval));
            }));

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && Time.time -  loopStartTime > 1f);

            StopCoroutine(fadeIn);
            StopCoroutine(showEachChar);

            if (i != contents.Length - 1 && images[GetImageIdx(i)] != images[GetImageIdx(i + 1)])
            {
                StartCoroutine(UIEffect.Fade(canvasGroup, 0f, 1f));

                yield return new WaitForSeconds(1f);
            }
        }

        onEndContents();
    }

    void InitContent(int loopCount)
    {
        textComponent.text = "";
        background.texture = images[GetImageIdx(loopCount)];
    }

    int GetImageIdx(int loopCount)
    {
        int idx = loopCount;

        while (images[idx] == null && idx > 0) idx--;

        return idx;
    }
}
