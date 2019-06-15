using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource BGM_Speaker;
    public AudioSource Effect_Speaker;
    public AudioClip[] BGM;
    public AudioClip[] EffectSound;

    public static SoundManager Get_instance()
    {
        if(instance == null)
        {
            instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
        }

        return instance;
    }
  
}
