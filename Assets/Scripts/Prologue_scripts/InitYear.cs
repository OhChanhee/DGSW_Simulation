using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitYear : MonoBehaviour
{
    public Text year;

    void Awake()
    {
        year.text = System.DateTime.Now.Year.ToString();
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
