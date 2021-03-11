using System;
using UnityEngine;

public class KakuroBox : InteractableBox
{
    public static KakuroBox kakuroBox;
    public static event Action Completed;
    [SerializeField] private GameObject board;
    private Player _player;

    private void Awake()
    {
        kakuroBox = this;
        hintHeight = 4f;
        isAlreadyUsed = false;
    }

    public void OnCompleted() => Completed?.Invoke();

    protected override void OnInteraction()
    {
        Instantiate(board);
        isAlreadyUsed = true;
    }
}
