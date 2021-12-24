using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusHealth : MonoBehaviour
{
    [SerializeField] private int initalHealth;
    [SerializeField] private string name;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = initalHealth;
    }

    public void TakeDamage(int damage)
    {
        print("damaged");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            print("mati");
            EnemyDied();
        }
    }

    private void EnemyDied()
    {
        // print("Enemy died");
        GetComponent<BoxCollider2D>().enabled = false;
        print("collider ilang");
        // GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<Animator>().enabled = false;
        print("anim ilang");
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
        GameObject.Find(name).SetActive(false);
        print("patrol ilang");

    }
}


