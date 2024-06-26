using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpinner : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;
    private float speed = 1;

    void Start()
    {
        if (playerMovment == null)
        {
            playerMovment = GameObject.Find("Ship").GetComponent<PlayerMovment>();
        }
    }

        // Update is called once per frame
        void Update()
    {
        speed = playerMovment.GetForwardSpeed();
        Vector3 rot = new Vector3(0,0,-speed);
        gameObject.transform.Rotate(rot * Time.deltaTime);
    }
}
