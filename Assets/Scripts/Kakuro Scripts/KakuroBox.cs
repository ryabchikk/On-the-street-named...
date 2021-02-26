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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
            Instantiate(board);
    }

    public void OnCompleted()
    {
        Completed?.Invoke();
    }
}
