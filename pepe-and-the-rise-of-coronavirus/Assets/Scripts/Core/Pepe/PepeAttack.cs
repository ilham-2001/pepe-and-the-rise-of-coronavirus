using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeAttack : MonoBehaviour
{
    [Header("Attack Parameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    private float cooldownTimer = Mathf.Infinity;

    private PepeMovement plyMove;
    void Start()
    {
        plyMove = GetComponent<PepeMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && plyMove.CanAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        // pool fireball
        projectiles[FindProjectile()].transform.position = firePoint.position;
        projectiles[FindProjectile()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindProjectile()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
