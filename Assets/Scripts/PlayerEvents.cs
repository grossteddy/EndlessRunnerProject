using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] float startingHp;
    private float hp;
    [SerializeField] float hpDamage;
    [SerializeField] UnityEvent gameOver;

    [SerializeField] float invulTimer;
    private bool vuln = true;
    private float currentTime;

    [SerializeField] Image healthBar;

    [SerializeField] GameObject gameUI;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Timer time;

    [SerializeField] GameObject shield;

    [SerializeField] Animator animator;

    private void Start()
    {
        hp = startingHp;
        vuln = true;
    }

    private void Update()
    {
        if (Time.time > currentTime)
        {
            vuln = true;
            shield.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        if (vuln)
        {
            animator.SetTrigger("Hit");
            hp = hp - hpDamage;
            ReduceHealthBar();
            MakeInvulnerable();
            shield.SetActive(true);
            if (hp <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        scoreText.text = time.currentTime.ToString("0.00");
        gameUI.SetActive(false);
        gameOver.Invoke();
    }

    private void MakeInvulnerable()
    {
        vuln = false;
        currentTime = Time.time + invulTimer;
    }

    private void ReduceHealthBar()
    {
        healthBar.fillAmount = healthBar.fillAmount - (1 / startingHp);
    }

    public void Heal()
    {
        if (hp < startingHp)
        {
            hp = hp + 1;
            IncreaseHealthBar();
        }
    }

    private void IncreaseHealthBar()
    {
        healthBar.fillAmount = healthBar.fillAmount + (1 / startingHp);
    }

}
