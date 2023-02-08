using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeActivation : MonoBehaviour
{
    private GameObject player;
    void Awake()
    {
        player = GetComponent<GameObject>();
        player.SetActive(false);
    }

    private void Start()
    {
        GameManager.instance.OnSnake += Activate;
        GameManager.instance.OnTutorial += Desactivate;
    }

    private void Desactivate()
    {
        player.SetActive(false);
    }

    private void Activate()
    {
        player.SetActive(true);
    }
}
