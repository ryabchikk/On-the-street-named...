using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт для объекта который будет вызывать какуро
//На объекте добавить триггер коллайдер в который нужно будет зайти чтобы начать
public class TestBox : MonoBehaviour
{
    [SerializeField]
    private GameObject board;               //В инспекторе сюда префаб доски

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
                StartTest(other.gameObject);
        }
    }

    private void StartTest(GameObject player)
    {
        player.SendMessage("MinigameState", true);
        Instantiate(board);
    }
}
