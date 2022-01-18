using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] arrayAttacksPrefabs;
    public Transform pointShot;

    [SerializeField] private float speed;

    private Rigidbody2D playerRigidbody2D;

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            print("Fire");
            InstantiateAttacks(0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            print("Water");
            InstantiateAttacks(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            InstantiateAttacks(2);
        }
    }

    void FixedUpdate()
    {
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, Input.GetAxisRaw("Vertical") * speed);
    }

    private void InstantiateAttacks(int value)
    {
        Instantiate(arrayAttacksPrefabs[value], pointShot.position, Quaternion.identity);
    }
}
