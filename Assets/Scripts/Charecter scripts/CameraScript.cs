using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//HOW TO:
//Подключить скрипт к камере
//В target объект игрока в инспекторе
//Настроить камеру в редакторе на нужню позицию

public class CameraScript : MonoBehaviour
{
    public Transform target;
    private Vector3 _pos;
    
    private void Start()
    {
        _pos = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + _pos;
    }
}

