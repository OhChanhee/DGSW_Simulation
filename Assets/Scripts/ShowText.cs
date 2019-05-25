using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowText : MonoBehaviour
{
    public Text textComponent;
    public string nextScene;
    string contents;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ReadText()
    {
        contents = textComponent.text;

        for (int i = 1; i <= contents.Length; i++)
        {
            textComponent.text = contents.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
