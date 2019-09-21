using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class subTexting : MonoBehaviour
{
    public Text textComponent;
    public string nextScene;
    string contents;

    void Start()
    {
        StartCoroutine(ReadText());
        PlayerPrefs.SetInt("whatEvent", 137);
    }

    public IEnumerator ReadText()
    {
        contents = textComponent.text;

        for (int i = 1; i <= contents.Length; i++)
        {
            textComponent.text = contents.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(nextScene);
    }
}
