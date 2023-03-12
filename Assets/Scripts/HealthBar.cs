using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HpBar;
    public float CurrentHealth;
    private int maxHealth = 100;

    PlayerStats player;

    private void Start()
    {
        HpBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        CurrentHealth = player.health;
        HpBar.fillAmount = CurrentHealth / maxHealth;
    }
}
