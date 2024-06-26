using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
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
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
