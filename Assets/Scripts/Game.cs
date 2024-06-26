using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    [SerializeField] PlayerEvents playerEvents;
    [SerializeField] int ringHp;

    public void RingHurt()
    {
        ringHp = ringHp - 1;

        if (ringHp <= 0)
        {
            playerEvents.GameOver();
        }
    }
}
