using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [SerializeField] UnityEvent pickupEvent;


    private void Update()
    {
        //if(Time.time > timeToDestory)
        //{
            //gameObject.GetComponent<PoolingObject>().ReturnToPool();
        //}
    }

    public void OnPickup()
    {
        pickupEvent.Invoke();
        RemovePickup();
    }

    private void RemovePickup()
    {
        gameObject.GetComponent<PoolingObject>().ReturnToPool();
    }
}
