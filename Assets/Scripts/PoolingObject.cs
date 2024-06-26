using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolingObject : MonoBehaviour
{
    [SerializeField] Pool myPool;
    Coroutine routine;
    public void Bind(Pool pool)
    {
        myPool = pool;
    }

    public void OnPulled()
    {
    }

    public void OnReturn()
    {

    }

    public void ReturnToPool()
    {
        myPool.Return(gameObject);
    }

    public void ReturnToPool(float time)
    {

        StartCoroutine(DestroyRoutine(time));

    }


    IEnumerator DestroyRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        myPool.Return(gameObject);
    }
}
