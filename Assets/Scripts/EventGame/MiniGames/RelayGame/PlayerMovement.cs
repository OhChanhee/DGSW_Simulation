using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject checkPointHolder;
    Vector2 checkPoint;
    int exerciseSkill;
    readonly List<Transform> checkPoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform checkPoint in checkPointHolder.transform)
        {
            checkPoints.Add(checkPoint);
        }

        checkPoints[0].gameObject.SetActive(true);

        checkPoint = transform.position;
        exerciseSkill = CharacterManager.Get_instance().characterStat.exercise;
        exerciseSkill = 700;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        transform.Translate(direction * exerciseSkill * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "grass")
        {
            transform.position = checkPoint;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "checkPoint")
        {
            checkPoint = col.gameObject.transform.position;
            checkPoints.ToArray()[checkPoints.IndexOf(col.transform) + 1].gameObject.SetActive(true);
        }
    }
}
