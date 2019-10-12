using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utilities;
using System.Threading.Tasks;
using System.Threading;
using System;

public class TaskManager : MonoBehaviour
{
    /**
     * delay만큼 기다린 후 action을 수행합니다.
     */
    public static Coroutine Delay(float delay, Action action, Action onEnd = null)
    {
        return StaticObject.instance.StartCoroutine(_Delay(delay, action, onEnd));
    }

    private static IEnumerator _Delay(float delay, Action action, Action onEnd)
    {
        yield return new WaitForSeconds(delay);
        action();
        Callback(onEnd);
    }

    public static void Callback(Action action)
    {
        if (action == null) return;
        action();
    }
}
