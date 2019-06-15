using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGender : MonoBehaviour
{
    public Button genderM, genderF;

    // Start is called before the first frame update
    void Start()
    {
        genderM.onClick.AddListener(SetGenderM);
        genderF.onClick.AddListener(SetGenderF);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGenderM()
    {
        CharacterManager.Get_instance().gender = Gender.man;
    }

    void SetGenderF()
    {
        CharacterManager.Get_instance().gender = Gender.woman;
    }
}
