using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать

public class TestBox : MonoBehaviour
{
    public static TestBox testBox;
    [SerializeField] private GameObject board;               //В инспекторе сюда префаб доски
    [SerializeField] private Text text;
    private Player _player;
    private bool _flashCollected;
    private bool _kakuroCompleted;
    
    private void Start()
    {
        testBox = this;
        _player = Player.player;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            if (_flashCollected && _kakuroCompleted)
                StartTest();
            else
                Debug.Log("TODO добавить сообщение о том, что не все пройдено");
        }
            
    }

    public void OnFlashCollected() => _flashCollected = true;

    public void OnKakuroCompleted() => _kakuroCompleted = true;

    private void StartTest()
    {
        _player.DeactivateShooting();
        Instantiate(board);
        text.enabled=true;
    }
}
