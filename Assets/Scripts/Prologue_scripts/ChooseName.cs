using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseName : MonoBehaviour
{
    public InputField PName;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        PName.onEndEdit.AddListener(SetName);
        StartCoroutine(UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 1.0f, 1.0f));
    }

    void SetName(string name)
    {
        CharacterManager.Get_instance().playerName = name;
        StartCoroutine(UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 0f, 1.0f));
        StartCoroutine(TaskManager.Delay(1.0f, () => { SceneManager.LoadScene("Prologue_birthday", LoadSceneMode.Single); }));
    }
}
