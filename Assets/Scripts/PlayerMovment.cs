using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovment : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] Transform toRotateHorizontal; //Please provide child object of ship grathics (Grandchild of ship)
    [SerializeField] Transform toRotateVertical; //Please provide child object of ship
    [SerializeField] Transform aimTarget;

    [Header("Movment Settings")]
    [SerializeField] float speed; //speed of horizontal vertical movment
    [SerializeField] float xRange; // horizontal x range going from x to -x
    [SerializeField] float yRange; // vertical y range going from 0 to y
    [SerializeField] float forewardSpeed;

    [Header("Rotation Settings")]
    [SerializeField] float HorRotSpeed;
    [SerializeField] float HorRotLimit;
    [SerializeField] float VerRotSpeed;
    [SerializeField] float VerticalRotationMult;
    


    private Vector3 dir;

    private void Update()
    {
        Movment(xRange, yRange, speed);
        HorizontalRotation();
        VerticalRotation();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.transform.parent.parent.GetComponent<Enemy>().Die();
            //collider.GetComponent<Enemy>().Die();
        }
    }

    private void Movment(float xRange, float yRange, float speed)
    {
        dir = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.up * Input.GetAxisRaw("Vertical");
        //Vector3.forward* forewardSpeed - This was made as a forward movment 

        if ((transform.localPosition.x >= xRange && dir.x > 0) ||
            (transform.localPosition.x <= (-1 * xRange) && dir.x < 0))
        {
            dir.x = 0;
        }

        if ((transform.localPosition.y >= yRange && dir.y > 0) ||
            (transform.localPosition.y <= (-1 * yRange) && dir.y < 0))
        {
            dir.y = 0;
        }

        transform.Translate(dir * speed * Time.deltaTime, Space.Self);
    }

    private void HorizontalRotation()
    {
        Vector3 eulerAngles = toRotateHorizontal.localEulerAngles;
        toRotateHorizontal.localEulerAngles = new Vector3(eulerAngles.x, eulerAngles.y, Mathf.LerpAngle(eulerAngles.z, -dir.x * HorRotLimit,
            HorRotSpeed * Time.deltaTime));
    }

    private void VerticalRotation()
    {
        aimTarget.localPosition = new Vector3(0, dir.y * VerticalRotationMult, aimTarget.localPosition.z);
        Vector3 relativePos = (aimTarget.localPosition - toRotateVertical.localPosition).normalized;
        toRotateVertical.localRotation = Quaternion.RotateTowards(toRotateVertical.localRotation, Quaternion.LookRotation(relativePos), Mathf.Rad2Deg * VerRotSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            PickUp pickupHit = collision.gameObject.GetComponent<PickUp>();
            pickupHit.OnPickup();
        }
    }

    public Vector2 GetXYMaxRange()
    {
        Vector2 range = new Vector2(xRange, yRange);
        return range;
    }

    public float GetForwardSpeed()
    {
        return forewardSpeed;
    }

}