using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string tagCollisionsForDestroyThis;
    [SerializeField] private string tagCollisionsForIncreaseSpeed;

    private Rigidbody2D enemieRigidbody2D;

    void Awake()
    {
        enemieRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemieRigidbody2D.velocity = new Vector2(-speed * Time.deltaTime, enemieRigidbody2D.velocity.y);

        if (transform.position.x <= -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagCollisionsForDestroyThis)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == tagCollisionsForIncreaseSpeed)
        {
            speed += 100;
        }
    }
}
