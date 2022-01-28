using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEspecial : MonoBehaviour
{
    public static PlayerEspecial instance;

    public Image barEspecial;
    private bool isFullEspecial = false;

    private void Start()
    {
        instance = this;
    }
}
