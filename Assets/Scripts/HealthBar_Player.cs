﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject showDmg;
    [SerializeField] private Transform container;

    
    // Start is called before the first frame update
    public float health;
    float maxHealth=100;
    public Image healthBar;
    float lerpSpeed;
    
    void Start()
    {
        health=maxHealth;
        ObjectPoolManager.instance.PreCachePool(showDmg, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) health = 0;
        if(health>maxHealth) health = maxHealth;
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
    }
    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed); ;

    }
    public void Damage(float damagePoints)
    {
        if(health > 0)
        {
            print("Đã nhận damage. Trừ máu");
            health -= damagePoints;
            var obj = ObjectPoolManager.Spawn(showDmg);
            obj.transform.SetParent(container);
            obj.SetActive(true);
            var script = obj.GetComponent<ShowDmg>();
            script.Init(damagePoints, transform.position);
        }
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {
            print("Đã phục hồi máu");
            health += healingPoints;
        }
    }
    public float getCurrentHealth()
    {
        return health;
    }
    public float getMaxHealth()
    {
        return maxHealth;
    }
}
