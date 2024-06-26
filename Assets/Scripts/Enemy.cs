using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Object;
    [SerializeField] GameObject Explosion;
    private bool alive = false;

    public PlayerEvents collisionEvent;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && alive)
        {
            collisionEvent.TakeDamage();
        }
    }

    public void Die()
    {
        Object.SetActive(false);
        gameObject.tag = "Interactable";
        alive = false;
        Explosion.SetActive(true);
    }
}
