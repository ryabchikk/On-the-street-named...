using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    //Основные параметры
    public float speed;// скорость персонажа
    public float jumpPow;//сила прыжка
    public float sensivity;// сокрость поворота персонажа с помощью мыши
    
    //Параметры геймплея для персонажа
    private float gravForce;//гравитация персонажа
    private Vector3 moveVector;//направление движения пресонажа

    //Ссылки на компонетны
    private CharacterController ch_controller;
    private Animator ch_animator;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        //ch_animator = GetComponent<Animator>();
    }

    void Update()
    {
        //не рабочая часть,персонаж не следит за курсором нормально
        /*if (transform.rotation.y >= 90)
            transform.Rotate(0, Input.GetAxis("Mouse Y") * sensivity, 0);
        else
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivity, 0);*/
        CharacterMove();
        GamingGravity();
        
    }
    private void CharacterMove() 
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.z = Input.GetAxis("Vertical") * speed;
        
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        
        moveVector.y = gravForce;
        ch_controller.Move(moveVector * Time.deltaTime);//метод движения по направлению

    }
    //метод гравитации
    private void GamingGravity() 
    {
        if (!ch_controller.isGrounded) gravForce -= 50f * Time.deltaTime;
        else gravForce = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravForce = jumpPow;
    }
    // if (Input.GetAxis("Mouse Y") < 0)
        //{
        //  transform.Rotate(0, -Input.GetAxis("Mouse X") * sensivity, 0);
        // }
        //else 
        //{
        //transform.Rotate(0,(float)Math.Sin(Math.Abs(transform.position.z - Input.GetAxis("Mouse Y"))/Math.Sqrt(Math.Pow(transform.position.x-Input.GetAxis("Mouse X"),2)+Math.Pow(transform.position.z - Input.GetAxis("Mouse Y"), 2)))*sensivity, 0);
        //}
}
