using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCristals : MonoBehaviour
{
    public Sprite spriteBroken;
    public GameObject explosionPrefab;

    private SpriteRenderer mySprite;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            mySprite.sprite = spriteBroken;
            gameObject.tag = "Untagged";
            boxCollider2D.enabled = false;
            GameOver.instance.totalCristalsInScene--;
        }
    }
}
