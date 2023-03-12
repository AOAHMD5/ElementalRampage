using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{
    private Image HpBar;
    public float CurrentHealth;
    private int maxHealth = 100;
    BossAI bossHP;

    // Start is called before the first frame update
    void Start()
    {
        HpBar = GetComponent<Image>();
        bossHP = FindObjectOfType<BossAI>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = bossHP.health;
        HpBar.fillAmount = CurrentHealth / maxHealth;
    }
}