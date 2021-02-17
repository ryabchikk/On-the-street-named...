using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт кнопки проверки
//Кнопка должна быть внутри Board

public class SubmitButton : MonoBehaviour
{
    private Board _board;
    private Player _player;
    private TestBox _testBox;
    void Start()
    {
        _board = GameObject.FindWithTag("Board").GetComponent<Board>();
        _player = Player.player;
        _testBox = TestBox.testBox;
    }
    
    void Click()
    {
        if (_board.CheckSums())
        {
            _player.ActivateShooting();
            _testBox.OnKakuroCompleted();
            Destroy(_board.gameObject);
        }
        else 
        { 
            _board.WrongNumbers();
        }
    }
}


