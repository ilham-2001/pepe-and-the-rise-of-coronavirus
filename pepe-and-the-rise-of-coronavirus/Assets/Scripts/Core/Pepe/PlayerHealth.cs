using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float initialHealth = 1f;
    private Animator anim;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = initialHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        anim.SetTrigger("attacked");
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, initialHealth);


        if (currentHealth <= 0)
        {
            GetComponent<PepeMovement>().enabled = false;
            GameObject.Find("Pepe Ver 2.0").SetActive(false);
        }

    }
}
