using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMonth : MonoBehaviour
{
    public Text month;

    void Awake()
    {
        month.text = System.DateTime.Now.Month.ToString();
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
