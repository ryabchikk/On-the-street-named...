using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBox : InteractableBox
{
    public static CheckersBox checkersBox;
    [SerializeField] private CheckersBoard board;

    private void Awake()
    {
        hintHeight = 4f;
        checkersBox = this;
    }

    protected override void OnInteraction()
    {
        Instantiate(board);
        isAlreadyUsed = true;
    }
}
