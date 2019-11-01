using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectGender : MonoBehaviour
{
    public Button genderM, genderF;
    public Canvas canvas;

    Coroutine fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        genderM.onClick.AddListener(SetGenderM);
        genderF.onClick.AddListener(SetGenderF);
        fadeIn = UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 1.0f, 1.0f);
    }

    void SetGenderM()
    {
        CharacterManager.Get_instance().gender = Gender.man;

        EndScene();
    }

    void SetGenderF()
    {
        CharacterManager.Get_instance().gender = Gender.woman;

        EndScene();
    }

    void EndScene()
    {
        StopCoroutine(fadeIn);
        UIEffect.Fade(canvas.GetComponent<CanvasGroup>(), 0.0f, 1.0f);
        TaskManager.Delay(1.0f, () => { SceneManager.LoadScene("Prologue_name", LoadSceneMode.Single); });
    }
}
