using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт на простейшее передвижение врагов
//Если игрок подошел близко, начинает идти в его сторону
//Это очень ранняя пре альфа версия

//TODO:
//Сделать перемещение физическим

public class EnemyScript : MonoBehaviour
{
    public Transform player;                        //Позиция игрока
    private Transform enemy;                        //Позиция врага
    private float aggrDistance = 15f;               //Дистанция агра, менять на готовой карте
    private bool isTriggered = false;               //Требуется, если нужно, чтобы враг преследовал героя на любой дистанции
    void Start()
    {
        enemy = this.transform;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, enemy.position) < aggrDistance || isTriggered)                //Если игрок подошел на дистанцию агра
        {
            Triggered();
        }
    }

    //Сюда можно прописать другую логику триггера
    void Triggered()
    {
        isTriggered = true;
        enemy.position = Vector3.MoveTowards(enemy.position, player.position, Time.deltaTime*10);
    }
}
