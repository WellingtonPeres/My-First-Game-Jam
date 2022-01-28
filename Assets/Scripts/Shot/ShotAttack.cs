using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAttack : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioSource SFXAttack;

    [SerializeField] private float speed;

    private Rigidbody2D shotRigidbody2D;

    private void Awake()
    {
        shotRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        shotRigidbody2D.velocity = new Vector2(speed * Time.deltaTime, shotRigidbody2D.velocity.y);

        if (transform.position.x >= 8.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Instantiate(SFXAttack, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
