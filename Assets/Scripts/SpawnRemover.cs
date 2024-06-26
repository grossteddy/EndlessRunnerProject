using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRemover : MonoBehaviour
{

    [SerializeField] Game game;
    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Blocker"))
        {
            game.RingHurt();
            collider.gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }

        if (collider.gameObject.CompareTag("Interactable"))
        {
            collider.gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }
    }
}
