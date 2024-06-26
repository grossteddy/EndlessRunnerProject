using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float currentTime;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
    }
}
