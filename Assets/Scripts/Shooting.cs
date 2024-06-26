using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    [SerializeField] GameObject lightLeft;
    [SerializeField] GameObject lightRight;

    [SerializeField] Pool laserPool;

    [SerializeField] float timer;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            currentTime = Time.time + timer;
        }

        if (Time.time <= currentTime)
        {
            lightLeft.SetActive(true);
            lightRight.SetActive(true);
        }

        else
        {
            lightLeft.SetActive(false);
            lightRight.SetActive(false);
        }

    }

    private void Shoot()
    {
        GameObject pulled = laserPool.Pull(left.position, left.rotation);
        GameObject pulled2 = laserPool.Pull(right.position, right.rotation);

        pulled.GetComponent<Laser>().Init();
        pulled2.GetComponent<Laser>().Init();
    }
}
