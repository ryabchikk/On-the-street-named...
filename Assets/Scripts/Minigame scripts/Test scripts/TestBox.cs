using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать

public class TestBox : InteractableBox
{
    [SerializeField] private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField] private Text text;
    private Player _player;
    private bool _flashCollected;
    private bool _kakuroCompleted;
    private bool _lockCompleted;
    
    private void Start()
    {
        _player = Player.player;
        KakuroBox.Completed += OnKakuroCompleted;
        FlashDrive.Collected += OnFlashCollected;
        Lock.Completed += OnLockCompleted;
        hintHeight = 18f;
    }

    private void OnFlashCollected() => _flashCollected = true;

    private void OnKakuroCompleted() => _kakuroCompleted = true;

    private void OnLockCompleted() => _lockCompleted = true;

    protected override void OnInteraction()
    {
        if (_flashCollected && _kakuroCompleted && _lockCompleted)
            StartTest();
        else
            Debug.Log("TODO добавить сообщение о том, что не все пройдено");
    }

    private void StartTest()
    {
        _player.DeactivateShooting();
        Instantiate(board);
        text.enabled=true;
    }
}
