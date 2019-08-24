using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIMovement : MonoBehaviour
{
    public GameObject wayPointHolder;
    public int loopCount;
    float exerciseSkill;
    bool isCirculationEnd;

    // Start is called before the first frame update
    public void Start()
    {
        isCirculationEnd = false;
        exerciseSkill = Random.Range(.4f, .5f);
        StartCoroutine(loopCirculation());
    }

    public abstract void endCirculation();

    IEnumerator loopCirculation()
    {
        Vector2[] wayPoints = new Vector2[wayPointHolder.transform.childCount];

        for(int i = 0; i < wayPointHolder.transform.childCount; i++)
        {
            Transform wayPoint = wayPointHolder.transform.GetChild(i);

            wayPoints.SetValue(new Vector2(wayPoint.position.x, wayPoint.position.y), i);
        }

        for (int i = 0; i < loopCount; i++)
        {
            StartCoroutine(Circulation(wayPoints));

            yield return new WaitUntil(() => isCirculationEnd);
        }

        this.gameObject.SetActive(false);
        endCirculation();
    }
    
    IEnumerator Circulation(Vector2[] wayPoints)
    {
        isCirculationEnd = false;

        for (int i = 0; i < wayPoints.Length; i++)
        {
            Vector2 nextPoint = wayPoints[(i == wayPoints.Length - 1 ? 0 : i + 1)];

            transform.position = wayPoints[i];

            yield return new WaitForSeconds(Vector2.Distance(wayPoints[i], nextPoint) / exerciseSkill * Time.deltaTime * .1f);
        }
        
        isCirculationEnd = true;
    }
}