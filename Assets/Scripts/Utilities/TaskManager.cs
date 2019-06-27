using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System;

public class TaskManager : MonoBehaviour
{
    /**
     * delay만큼 기다린 후 action을 수행합니다.
     */
    public static IEnumerator Delay(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
