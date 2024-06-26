using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour
{
    public PlayerEvents collisionEvent;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collisionEvent.Heal();
            gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }
    }
}
