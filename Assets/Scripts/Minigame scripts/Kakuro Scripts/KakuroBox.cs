using System;
using UnityEngine;

public class KakuroBox : InteractableBox
{
    public static KakuroBox kakuroBox;
    [SerializeField] private GameObject board;
    private Player _player;

    private void Awake()
    {
        kakuroBox = this;
        hintHeight = 4f;
        isAlreadyUsed = false;
    }

    protected override void OnInteraction()
    {
        Instantiate(board);
        isAlreadyUsed = true;
    }
}
