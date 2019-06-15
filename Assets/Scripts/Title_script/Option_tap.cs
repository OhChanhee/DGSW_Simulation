using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option_tap : Tap
{
    public Button exit;
    public Button window_btn;
    public Button fullscreen_btn;
    public Slider effect_bar;
    public Slider bgm_bar;


    public void Change_effect()
    {
        SoundManager.Get_instance().Effect_Speaker.volume = effect_bar.value;
    }

    public void Change_bgm()
    {
        SoundManager.Get_instance().BGM_Speaker.volume = bgm_bar.value;
    }

    public void Set_windowMode()
    {
        Screen.fullScreen = false;
    }
    
    public void Set_fullscreen()
    {
        Screen.fullScreen = true;
    }

    
    
   
}
