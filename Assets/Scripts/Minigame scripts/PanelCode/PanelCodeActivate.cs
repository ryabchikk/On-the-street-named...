using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCodeActivate : InteractableBox
{
    [SerializeField] private GameObject board;

    private void Start()
    {
        hintHeight = 12f;
    }

    protected override void OnInteraction()
    {
        board.SetActive(true);
        isAlreadyUsed = true;
    }
}
