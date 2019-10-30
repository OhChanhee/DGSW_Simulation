using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SceneController_Event : MonoBehaviour
{
    public RawImage background;
    public Texture2D[] images;
    public Text textComponent;
    public float showCharInterval;
    public CanvasGroup canvasGroup;
    public Button next_btn;
    public string nextScene;
    string[] contents;

    private bool isclick = false;
    // Start is called before the first frame update
    void Start()
    {
        next_btn.onClick.AddListener(btn_click);
        contents = textComponent.text.Split('|');

        StartCoroutine(ShowContents(() =>
        {
            UIEffect.Fade(canvasGroup, 0f, 1f);
            TaskManager.Delay(1f, () => SceneManager.LoadScene(nextScene));
        }));
    }

    void btn_click()
    {
        isclick = true;
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

            Coroutine fadeIn = UIEffect.Fade(canvasGroup, 1f, 1f);

            Coroutine showEachChar = TaskManager.Delay(1f, () =>
            {
                textComponent.text = contents[i];
                UIEffect.ShowEachChar(textComponent, showCharInterval);
            });

            yield return new WaitUntil(() => isclick && Time.time - loopStartTime > 1f );

            StopCoroutine(fadeIn);
            StopCoroutine(showEachChar);

            if (i != contents.Length - 1 && images[GetImageIdx(i)] != images[GetImageIdx(i + 1)])
            {
                UIEffect.Fade(canvasGroup, 0f, 1f);

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
