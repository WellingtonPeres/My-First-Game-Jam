using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAttack : MonoBehaviour
{
    private AudioSource SFX;

    void Start()
    {
        SFX = GetComponent<AudioSource>();
        Destroy(gameObject, 0.5f);
    }
}
