using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject ramen;
    public GameObject chopSticks;
    private float[,] ramenPlaces;
    private float[,] chopPlaces;

void Start()
    {
        ramenPlaces = new float[4, 3]
        {
            {-20.54f, 0.54f, 184.32f},
            {-20.54f, 11.36f, -184.32f},
            {-20.54f, 0.54f, 55.93f},
            {62.08f, 11.36f, -180.28f}
        };

        chopPlaces = new float[4, 3]
        {
            {-24.5f, 13.36f, -106.2f},
            {41.07f, 13.36f, -43.75f},
            {56.73f, 13.36f, 140.73f},
            {51.8f, 0.54f, 142.21f },
        };

        int ramenRandom = ramenRand();
        int chopRandom = chopRand();

        Vector3 ramenVector = new Vector3(ramenPlaces[ramenRandom, 0], ramenPlaces[ramenRandom, 1], ramenPlaces[ramenRandom, 2]);
        Vector3 chopVector = new Vector3(chopPlaces[chopRandom, 0], chopPlaces[chopRandom, 1], chopPlaces[chopRandom, 2]);

        ramen.transform.position = ramenVector;
        chopSticks.transform.position = chopVector;

        //Instantiate(ramen, ramenVector, Quaternion.identity);
        //Instantiate(chopSticks, chopVector, Quaternion.identity);
    }

    public int chopRand()
    {
        return Random.Range(0, 3);
    }

    public int ramenRand()
    {
        return Random.Range(0, 3);
    }
}
