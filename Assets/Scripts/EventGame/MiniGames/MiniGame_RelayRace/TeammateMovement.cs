using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeammateMovement : AIMovement
{
    public RawImage player;

    public override void endCirculate()
    {
        player.gameObject.SetActive(true);
    }
}
