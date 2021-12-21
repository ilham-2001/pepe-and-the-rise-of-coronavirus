using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D col)
    {
        // print("Hit player");
        if (col.tag == "Player")
        {
            print("Msk player");
            col.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
