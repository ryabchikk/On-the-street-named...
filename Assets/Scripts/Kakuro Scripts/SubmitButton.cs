using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт кнопки проверки
//Кнопка должна быть внутри Board

public class SubmitButton : MonoBehaviour
{
    private Board board;
    void Start()
    {
        //Доска
        board = GameObject.FindWithTag("Board").GetComponent<Board>();
    }

    //Вызывается по клику
    //По сути заглушка для обработки результата
    void Click()
    {
        if (board.CheckSums())
            Destroy(board.gameObject, 1f);

        else
            board.WrongNumbers();
    }
}


