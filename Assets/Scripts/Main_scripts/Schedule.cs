using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    [HideInInspector]
    public List<Act> actList = new List<Act>();

    [HideInInspector]
    public float progressPoint = 0f;
}
