using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashDrive : MonoBehaviour
{
    [SerializeField] private Text text;
    private TestBox _testBox;

    private void Start()
    {
        _testBox = TestBox.testBox;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") || !Input.GetKey("e")) return;
        
        _testBox.OnFlashCollected();
        Destroy(gameObject);
        text.enabled = true;
    }
}
