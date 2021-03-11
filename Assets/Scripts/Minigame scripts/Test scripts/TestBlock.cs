using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TestBlock : MonoBehaviour
{
    public Text text;
    public bool isCorrect;
    private TestBoard _board;
    private bool _isLast;

    void Start()
    {
        //Доска
        _board = GameObject.FindGameObjectWithTag("Board").GetComponent<TestBoard>();
        //Текст этой кнопки
        text = GetComponentInChildren<Text>();
        if(_isLast)
            _board.NextQuestion();
    }
    
    //Костыль
    public void Last()
    {
        _isLast = true;
    }

    private void Click()
    {
        if (isCorrect)
            _board.NextQuestion();
        else
            _board.Lose();
    }
}
