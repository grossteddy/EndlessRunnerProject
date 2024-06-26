using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float timer;
    private float currentTime;
    [SerializeField] float speed;
    [SerializeField] PoolingObject poolingObject;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Time.time > currentTime)
        {
            gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.transform.parent.parent.GetComponent<Enemy>().Die();
            //collider.GetComponent<Enemy>().Die();
            gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }

        if (collider.CompareTag("Interactable") || collider.CompareTag("World"))
        {
            gameObject.GetComponent<PoolingObject>().ReturnToPool();
        }

    }

    public void Init()
    {
        currentTime = Time.time + timer;
    }
}
