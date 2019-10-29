using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItem : MonoBehaviour
{
    public void OnMouseDown()
    {
        Invoke("setActive", 0.1f);
    }

    public void setActive()
    {
        gameObject.SetActive(false);
    }
}
