using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject test;

    private void OnTriggerEnter(Collider other)
    {
        test.SetActive(true);
        Time.timeScale = 0;
    }
}
