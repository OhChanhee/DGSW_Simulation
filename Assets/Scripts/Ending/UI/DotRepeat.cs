using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotRepeat : MonoBehaviour
{
    public Text textComponent;

    void Start()
    {
        UIEffect.DotRepeat(textComponent, .5f, 3);
    }
}
