using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Acting : MonoBehaviour
{
    public Text Title;
    public Text Description;
    [HideInInspector]
    public eCategory category;
    public CharacterStat Changement;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click_Acting);
    }

    void Click_Acting()
    {
        DataManager dataManager = new DataManager();
    }

}
