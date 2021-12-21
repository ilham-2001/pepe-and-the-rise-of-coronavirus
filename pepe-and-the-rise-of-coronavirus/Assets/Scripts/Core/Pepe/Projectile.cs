using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private BoxCollider2D boxCol;
    private float lifeTime;
    [SerializeField] float projectileDuration;

    void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (hit)
        {
            return;
        }

        // print("dir:" + direction);
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(0, movementSpeed, 0);

        lifeTime += Time.deltaTime;
        print("lifetime:" + lifeTime);
        print("duration:" + projectileDuration);

        if (lifeTime > projectileDuration)
        {
            print("msk if");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        hit = true;
        boxCol.enabled = false;

        if (col.tag == "Enemy")
        {
            col.GetComponent<VirusHealth>().TakeDamage(1);
        }
    }

    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        print("scale pepe:" + _direction);
        direction = _direction;
        gameObject.SetActive(true);
        boxCol.enabled = true;
        hit = false;

        float localScaleX = transform.localScale.x;
        print("scale arrow:" + localScaleX);

        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
            print("local arrow now:" + localScaleX);
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
