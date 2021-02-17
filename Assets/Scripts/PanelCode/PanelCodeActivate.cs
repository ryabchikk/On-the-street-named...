using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCodeActivate : MonoBehaviour
{
    [SerializeField] private GameObject board;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown("e"))
            board.SetActive(true);
    }
}
