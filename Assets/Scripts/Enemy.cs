using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public static float scale = 0;
    private EnemySpawner enemySpawner;

    public float Health
    {
        set
        {
            health = value;

            if(health <= 0)
            {
                scale = Random.Range(5, 15);
                health = scale;
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        DropLoot();
        if (enemySpawner != null)
        {
            enemySpawner.EnemyDefeated();
        }
        Destroy(gameObject);
    }

    private void DropLoot()
    {
        if (GetComponent<LootBag>() != null)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }
}