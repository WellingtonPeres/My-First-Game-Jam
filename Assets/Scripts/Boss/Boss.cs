using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public delegate void OnWinner();
    public static event OnWinner onWinner;

    public static Boss instance;

    [Header("Informations Boss")]
    public float totalLife;
    public GameObject explosionPrefab;
    public GameObject lifeBoss;
    public Image imageLifeBoss;

    [Header("Start Move Boss")]
    [SerializeField] private float speedBoss;
    [SerializeField] private Transform pointPointStopBoss;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (TimeWave.instance.imageWave.fillAmount == 1)
        {
            lifeBoss.SetActive(true);
            MoveBoss();
        }

        if (totalLife == 0)
        {
            if (onWinner != null)
            {
                onWinner();
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void MoveBoss()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointPointStopBoss.position, speedBoss * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Especial")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            imageLifeBoss.fillAmount -= 0.25f;
            totalLife--;
            Destroy(collision.gameObject);
        }
    }
}
