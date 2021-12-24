using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D enemyCol;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    // References                               
    private PlayerHealth ply;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    private EnemyPatrol patrol;


    void Start()
    {
        // Use to debug 
    }


    void Awake()
    {
        patrol = GetComponentInParent<EnemyPatrol>();
    }
    void Update()
    {
        EnemyAttacking();
    }

    private void EnemyAttacking()
    {
        // print(PlayerInSight());
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                RangedAttack();
                cooldownTimer = 0;
            }
        }

        if (patrol != null)
        {
            patrol.enabled = !PlayerInSight();
        }
    }

    private int FindArrows()
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
    private void RangedAttack()
    {
        cooldownTimer = 0;
        projectiles[FindArrows()].transform.position = firePoint.position;
        projectiles[FindArrows()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }


    private bool PlayerInSight()
    {
        RaycastHit2D hit =
    Physics2D.BoxCast(enemyCol.bounds.center + transform.right * range * (transform.localScale.x / 4) * colliderDistance,
    new Vector3(enemyCol.bounds.size.x * range, enemyCol.bounds.size.y, enemyCol.bounds.size.z),
    0, Vector2.left, 0, playerLayer);

        print(hit.collider);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(enemyCol.bounds.center + transform.right * range * (transform.localScale.x / 4) * colliderDistance,
            new Vector3(enemyCol.bounds.size.x * range, enemyCol.bounds.size.y, enemyCol.bounds.size.z));
    }

}

