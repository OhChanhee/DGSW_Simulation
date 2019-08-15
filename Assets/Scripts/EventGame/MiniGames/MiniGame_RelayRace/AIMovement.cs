using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIMovement : MonoBehaviour
{
    public GameObject wayPointHolder;
    public int loopCount;
    delegate void Method();
    Method move;
    float exerciseSkill;

    // Start is called before the first frame update
    public void Start()
    {
        exerciseSkill = Random.Range(.6f, .7f);
        StartCoroutine(Circulate());
    }

    // Update is called once per frame
    public void Update()
    {
        move();
    }

    public abstract void endCirculate();

    IEnumerator Circulate()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach (Transform wayPoint in wayPointHolder.transform)
        {
            wayPoints.Add(wayPoint);
        }

        Vector2[] pointsLocation = new Vector2[wayPoints.Count];

        for (int i = 0; i < wayPoints.Count; i++)
        {
            pointsLocation.SetValue(new Vector2(wayPoints[i].position.x, wayPoints[i].position.y), i);
        }

        for (int i = 0; i < loopCount; i++)
        {
            for (int j = 0; j < wayPoints.Count; j++)
            {
                Vector2 target = pointsLocation[(j == wayPoints.Count - 1 ? 0 : j + 1)];
                move = () => 
                {
                    transform.position = Vector3.MoveTowards(pointsLocation[j], target, exerciseSkill * Time.deltaTime * .1f);
                };
                
                yield return new WaitForSeconds(Vector2.Distance(pointsLocation[j], target) / exerciseSkill * Time.deltaTime * .1f);
                
                Debug.Log("Passed");
            }
        }

        this.gameObject.SetActive(false);
        endCirculate();
    }
}