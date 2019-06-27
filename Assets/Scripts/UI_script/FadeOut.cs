using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * ! Canvas에 CanvasGroup 컴포넌트를 추가한 후 사용해야 됩니다 !
 */
public class FadeOut : MonoBehaviour
{
    public Canvas canvas;
    public float startTime;
    public float duration;
    public string nextScene;
    delegate void method();
    method update;

    void Start()
    {
        update = delegate ()
        {
            if (Time.time >= startTime)
            {
                StartCoroutine(UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 0f, duration));
                update = delegate ()
                {
                    if(Time.time > startTime + duration)
                    {
                        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
                    }
                };
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        update();
    }
}
