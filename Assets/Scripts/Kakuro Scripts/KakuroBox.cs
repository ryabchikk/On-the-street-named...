using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakuroBox : MonoBehaviour
{
    [SerializeField] private GameObject board;
    private Player _player;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            Instantiate(board);
            _player = Player.player;
            _player.DeactivateShooting();
        }
    }
}
