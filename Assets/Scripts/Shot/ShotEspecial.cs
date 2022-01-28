using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEspecial : MonoBehaviour
{
    public GameObject explosionPrefab;

    [SerializeField] private float speed;

    private Rigidbody2D especialRigidbody2D;

    private void Awake()
    {
        especialRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        especialRigidbody2D.velocity = new Vector2(speed * Time.deltaTime, especialRigidbody2D.velocity.y);

        if (transform.position.x >= 8.5f)
        {
            Destroy(gameObject);
        }
    }
}
