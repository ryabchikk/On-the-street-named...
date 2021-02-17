using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Поставить врагу тег Enemy
//Скрипт в объект игрока
//Убрать камеру из игрока, обновить скрипт
//Создать слой Terrain и поставить на землю

public class ShootingScript : MonoBehaviour
{
    private LineRenderer _laserLine;
    private AudioSource _shootSound;
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
        _laserLine = GetComponent<LineRenderer>();
        _shootSound = GetComponent<AudioSource>();
    }
   
    private void Update()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Terrain");
        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask);//Каст луча из камеры через курсор чтобы получить точку в мире на которую указывает курсор
        transform.LookAt(hit.point);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);//Исправление вращения. Без этой строчки объект вращается по всем осям, а не тольно по Y
        if (Input.GetKeyDown(KeyCode.Mouse0))
            StartCoroutine(nameof(Shoot));
    }

    private void Shoot()
    {
        Physics.Raycast(new Ray(transform.position + new Vector3(0,-2,0), transform.forward), out var hit);
        _shootSound.Play();
        StartCoroutine(DrawLaser(hit));
        if (hit.collider.CompareTag("Enemy")) 
        {
            Destroy(hit.collider.gameObject);
            Debug.Log("popal");
        }
    }

    //Для плавности менять цифры в циклах
    //Time.deltaTime вместо константы для того чтобы не зависело от фпс
    //Добавить для луча материал
    private IEnumerator DrawLaser(RaycastHit hit)
    {
        _laserLine.SetPosition(0, transform.position);
        _laserLine.SetPosition(1, hit.point);

        _laserLine.SetPosition(0, transform.position);
        _laserLine.widthMultiplier = 1;
        yield return new WaitForSeconds(Time.deltaTime);
        
        while (_laserLine.widthMultiplier > 0)
        {
            _laserLine.SetPosition(0, transform.position);
            _laserLine.widthMultiplier -= 0.1f;
            yield return new WaitForSeconds(Time.deltaTime * 0.5f);
        }
        
    }
}