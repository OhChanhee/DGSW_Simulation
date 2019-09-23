using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTeacher : MonoBehaviour
{
    NavMeshAgent nva;
    Vector3 vector;
    Vector3 raiserPlace;
    Vector3 playerVector;
    Transform teacherTransform;
    Transform playerTransform;
    private float[,] places;
    private int place;
    private bool isPlayer = false;

    void Start()
    {
        nva = GetComponent<NavMeshAgent>();
        teacherTransform = GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        raiserPlace = new Vector3(teacherTransform.position.x, teacherTransform.position.y, teacherTransform.position.z + 3);
        playerVector = new Vector3(playerTransform.position.x, teacherTransform.position.y, playerTransform.position.z);

        //y축에서 1층은 1.25f, 2층은 13f
        places = new float[5, 3]
        {
            {1, 1.25f, 1},
            {20, 1.25f, -163},
            {20, 1.25f, 220},
            {20, 13, -163},
            {20, 13, 220}
        };
        roam();
    }

    void Update()
    {
        seeing();

        if ((vector.x + 1 >= teacherTransform.position.x && vector.x - 1 <= teacherTransform.position.x) && (vector.y + 1 >= teacherTransform.position.y && vector.y - 1 <= teacherTransform.position.y) && (vector.z + 1 >= teacherTransform.position.z && vector.z - 1 <= teacherTransform.position.z) || isPlayer == false)
        {
            roam();
        }
        else if(isPlayer == true)
        {
            playerVector = new Vector3(playerTransform.position.x, teacherTransform.position.y, playerTransform.position.z);
            nva.SetDestination(playerVector);
            Debug.Log(playerVector);
        }
    }

    public void roam()
    {
        nva.speed = 15f;
        place = Rand();
        Debug.Log(place);
        vector = new Vector3(places[place, 0], places[place, 1], places[place, 2]);
        nva.SetDestination(vector);
    }

    public int Rand()
    {
        return Random.Range(0, 4);
    }

    public void seeing()
    {
        float maxDistance = 50;
        RaycastHit hit;

        if (Physics.SphereCast(raiserPlace, transform.lossyScale.x / 2, transform.forward, out hit, maxDistance))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.name == "Player")
            {
                isPlayer = true;
            }
            else
            {
                isPlayer = false;
            }
        }
    }
}
 