using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//HOW TO:
//Поставить врагу тег Enemy
//Скрипт в объект игрока
//Убрать камеру из игрока, обновить скрипт
//Создать слой Terrain и поставить на землю

//Решение довольно костыльное
public class ShootingScript : MonoBehaviour
{
    private LineRenderer LaserLine;
    private void Start()
    {
        LaserLine = GetComponent<LineRenderer>();    
    }
   
    void Update()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Terrain");
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask);//Каст луча из камеры через курсор чтобы получить точку в мире на которую указывает курсор
        transform.LookAt(hit.point);//Всегда смотрит на эту точку
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);//Исправление вращения. Без этой строчки объект вращается по всем осям, а не тольно по Y
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(gameObject.transform.position+new Vector3(0,-2,0), gameObject.transform.forward), out hit);//Реализация хитскан механики
        //LaserLine.SetPosition(0, gameObject.transform.position);
        //LaserLine.SetPosition(1, hit.point);
        if (hit.collider.tag == "Enemy") 
        {
            
            Destroy(hit.collider.gameObject);
            Debug.Log("popal");
            
        }
        
        //Здесь может быть любой объект
        //И любая логика попадания
    }
}
