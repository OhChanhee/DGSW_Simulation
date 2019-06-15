using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseName : MonoBehaviour
{
    public InputField PName;

    // Start is called before the first frame update
    void Start()
    {
        PName.onEndEdit.AddListener(SetName);
    }

    void SetName(string name)
    {
        CharacterManager.Get_instance().playerName = name;
    }
}
