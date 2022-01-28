using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Point for Shots")]
    public Transform pointShot;
    public GameObject[] arrayAttacksPrefabs;

    [Header("Check if collider wall")]
    public float distanceRay;
    public LayerMask layerMaskCollider;

    [Header("Speed of the player")]
    [SerializeField] private float speed;

    [Header("SFX Attacks")]
    public AudioSource[] SFXs;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!GameOver.instance.isGameOver)
        {
            if (!PauseGame.instance.isPause)
            {
                Move();
                Attacks();
                ChangeSkinPlayerEspecial();
                AnimationWin();
            }
        }
    }

    void Move()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, distanceRay, layerMaskCollider);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, distanceRay, layerMaskCollider);

        if (!hitUp.collider)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
            }
        }
        if (!hitDown.collider)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 2f);
            }
        }
    }

    void Attacks()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RandomSFX();
            InstantiateAttacks(0, "Attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RandomSFX();
            InstantiateAttacks(1, "Attack");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            RandomSFX();
            InstantiateAttacks(2, "Attack");
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerEspecial.instance.barEspecial.fillAmount == 1f)
        {
            RandomSFX();
            InstantiateAttacks(3, "Attack");
            PlayerEspecial.instance.barEspecial.fillAmount = 0f;
            animator.SetBool("Especial", false);
        }
    }

    private void InstantiateAttacks(int value, string animatorName)
    {
        Instantiate(arrayAttacksPrefabs[value], pointShot.position, Quaternion.identity);
        animator.SetTrigger(animatorName);
    }

    private void ChangeSkinPlayerEspecial()
    {
        if (PlayerEspecial.instance.barEspecial.fillAmount == 1)
        {
            animator.SetBool("Especial", true);
        }
        else
        {
            animator.SetBool("Especial", false);
        }
    }

    private void AnimationWin()
    {
        if (Win.instance.isWin)
        {
            animator.SetBool("Win", true);
        }
    }

    private void RandomSFX()
    {
        var randSFX = Random.Range(0, SFXs.Length);
        SFXs[randSFX].Play();
    }
}
