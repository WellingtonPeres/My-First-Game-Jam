using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    [Header("Explosion")]
    public GameObject explosionPrefab;
    public GameObject explosionPrefabCristal;

    [Header("Up Gread Enemies")]
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

        if (transform.position.x <= -11 || Boss.instance.totalLife == 0 || Win.instance.isWin)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagCollisionsForDestroyThis || collision.gameObject.tag == "Especial")
        {
            if (collision.gameObject.tag == "Especial")
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                return;
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            PlayerEspecial.instance.barEspecial.fillAmount += 0.15f;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Cristal")
        {
            Instantiate(explosionPrefabCristal, transform.position, Quaternion.identity);

            PlayerEspecial.instance.barEspecial.fillAmount -= 0.15f;
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == tagCollisionsForIncreaseSpeed)
        {
            PlayerEspecial.instance.barEspecial.fillAmount -= 0.15f;
            speed += 100;
        }
    }
}
