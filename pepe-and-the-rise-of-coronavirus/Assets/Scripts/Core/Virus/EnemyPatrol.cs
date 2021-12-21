using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float enemyMs;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle behavior")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private void Awake()
    {
        initScale = enemy.localScale;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);

            else
            {
                // change direction
                DirectionChange();
            }

        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);

            else
            {
                // change direction
                DirectionChange();
            }
        }
    }

    private void MoveInDirection(int dir)
    {
        idleTimer = 0;
        // make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * dir, initScale.y, initScale.z);

        // move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * dir * enemyMs, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }
}
