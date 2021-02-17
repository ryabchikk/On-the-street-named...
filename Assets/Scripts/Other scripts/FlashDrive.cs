using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashDrive : MonoBehaviour
{
    public static event Action Collected;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player") || !Input.GetKey("e")) return;
        OnCollected();
        Destroy(gameObject);
    }

    private static void OnCollected()
    {
        Collected?.Invoke();
    }
}
