using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private Animator anim;
    private int currentHealth;
    public bool isDead = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (gameObject.name == "Boss")
        {
            anim.SetTrigger("attacked");
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            EnemyDied();
            if (gameObject.name == "Boss")
            {
                GameObject.Find("Cage").SetActive(false);
            }
        }
    }

    private void EnemyDied()
    {
        // print("Enemy died");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyPatrol>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }
}
