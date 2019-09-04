using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option_tap : Tap
{
    public Button exit;
    public Button window_btn;
    public Button fullscreen_btn;
    public Button reset_btn;
    public Button init_btn;
    public Slider effect_bar;
    public Slider bgm_bar;
    public Text effect_txt;
    public Text bgm_txt;

    void Start()
    {
        effect_bar.value = 0.5f;
        bgm_bar.value = 0.5f;
    }
    public void Change_effect()
    {
        effect_txt.text = string.Format("{0:f0}", effect_bar.value * 100);
    }

    public void Change_bgm()
    {
        bgm_txt.text = string.Format("{0:f0}", bgm_bar.value * 100);
    }


    public void Set_windowMode()
    {
        Screen.fullScreen = false;
    }
    
    public void Set_fullscreen()
    {
        Screen.fullScreen = true;
    }

    public void Onclick_apply_btn()
    {
        SoundManager.Get_instance().Effect_Speaker.volume = effect_bar.value;
        SoundManager.Get_instance().BGM_Speaker.volume = bgm_bar.value;
    }

    public void Onclick_init_btn()
    {
        effect_bar.value = 0.5f;
        bgm_bar.value = 0.5f;
        SoundManager.Get_instance().Effect_Speaker.volume = effect_bar.value;
        SoundManager.Get_instance().BGM_Speaker.volume = bgm_bar.value;
    }



}
