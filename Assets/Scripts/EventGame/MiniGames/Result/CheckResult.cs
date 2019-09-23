using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckResult : MonoBehaviour
{
    public SpriteRenderer title;
    public SpriteRenderer background;
    public Button done;

    void Awake()
    {
        string gameResult = PlayerPrefs.GetString("MinigameResult");

        title.sprite = Resources.Load<Sprite>("Clear/cl_" + gameResult + "Title");
        background.sprite = Resources.Load<Sprite>("Clear/cl_" + gameResult + "Bg");
        done.image.sprite = Resources.Load<Sprite>("Clear/cl_" + gameResult + "Confirm");

        PlayerPrefs.DeleteKey("MinigameResult");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
