using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Parameters")]
    [SerializeField] private float speed;
    [SerializeField] float projectileDuration;

    // private Animator anim;
    private bool hit;
    private float direction;
    private BoxCollider2D boxCol;
    private float lifeTime;

    void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
        // anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hit)
        {
            return; // return nothing mean to not execute the rest of the code
        }

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed * direction, 0, 0); // bug di sini
        lifeTime += Time.deltaTime;


        if (lifeTime > projectileDuration)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print("hitted something");
        hit = true;
        boxCol.enabled = false;
        Deactivate();

        if (col.tag == "Enemy")
        {
            col.GetComponent<VirusHealth>().TakeDamage(1);
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        boxCol.enabled = true;
        hit = false;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

// NOTE:
// Animator ada semacam konflik