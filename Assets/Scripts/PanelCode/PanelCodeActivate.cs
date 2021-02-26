using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCodeActivate : InteractableBox
{
    [SerializeField] private GameObject board;

    private void Start()
    {
        height = 12f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown("e"))
            board.SetActive(true);
    }
}
