using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRing : MonoBehaviour
{
    public PlayerEvents collisionEvent;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collisionEvent.TakeDamage();
        }
    }
}
