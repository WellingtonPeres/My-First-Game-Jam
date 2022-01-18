using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAttack : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D playerRigidbody2D;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = new Vector2(speed * Time.deltaTime, playerRigidbody2D.velocity.y);

        if (transform.position.x >= 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            Destroy(gameObject);
        }
    }
}
