using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActingList : MonoBehaviour
{
    public GameObject contents; 
    List<Ending> endingList;

    // Start is called before the first frame update
    void Start()
    {
        float contentsHeight = 0f;
        foreach (Transform transform in contents.transform)
        {
            contentsHeight += (transform as RectTransform).rect.height;
        }

        Rect contentsRect = (contents.transform as RectTransform).rect;
        (contents.transform as RectTransform).sizeDelta = new Vector2(contentsRect.x, contentsHeight);
    }
}
