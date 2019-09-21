using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckResult : MonoBehaviour
{
    public RawImage title;
    public RawImage background;
    public Button done;

    // Start is called before the first frame update
    void Start()
    {
        string gameResult = PlayerPrefs.GetString("MinigameResult");

        title.texture = Resources.Load<Texture>("/Clear/cl_" + gameResult + "Title");
        background.texture = Resources.Load<Texture>("/Clear/cl_" + gameResult + "Bg");
        done.image.sprite.texture = Resources.Load<Texture2D>("/Clear/cl_" + gameResult + "Confilm");
        PlayerPrefs.DeleteKey("MinigameResult");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
