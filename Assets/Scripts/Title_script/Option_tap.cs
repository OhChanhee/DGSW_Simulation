using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Option_tap : Tap
{
    public Button exit;
    public Button window_btn;
    public Button fullscreen_btn;
    public Button init_btn;
    public Button apply_btn;
    public Slider effect_bar;
    public Text effect_Value;
    public Slider bgm_bar;
    public Text bgm_Value;

    public void Start()
    {
        effect_Value.text = string.Format("{0:0}", SoundManager.Get_instance().Effect_Speaker.volume * 100);
        bgm_Value.text = string.Format("{0:0}", SoundManager.Get_instance().BGM_Speaker.volume * 100);
        effect_bar.value = SoundManager.Get_instance().Effect_Speaker.volume;
        bgm_bar.value = SoundManager.Get_instance().BGM_Speaker.volume;
    }
    public void Change_effect()
    {
       
        effect_Value.text = string.Format("{0:0}", effect_bar.value * 100);
    }

    public void Change_bgm()
    {
       
        bgm_Value.text = string.Format("{0:0}", bgm_bar.value * 100);
    }

    public void Set_windowMode()
    {
        Screen.fullScreen = false;
    }
    
    public void Set_fullscreen()
    {
        Screen.fullScreen = true;
    }

    public void Set_init()
    {
        SoundManager.Get_instance().Effect_Speaker.volume = 0.5f;
        SoundManager.Get_instance().BGM_Speaker.volume = 0.5f;
        effect_bar.value = 0.5f;
        bgm_bar.value = 0.5f;
        bgm_Value.text = string.Format("{0:0}", 50);
        effect_Value.text = string.Format("{0:0}", 50);
    }
    
    public void Set_apply()
    {
        SoundManager.Get_instance().Effect_Speaker.volume = effect_bar.value;
        SoundManager.Get_instance().BGM_Speaker.volume = bgm_bar.value;
    }
    
   
}
