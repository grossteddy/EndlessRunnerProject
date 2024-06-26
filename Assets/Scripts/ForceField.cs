using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForceField : MonoBehaviour
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
