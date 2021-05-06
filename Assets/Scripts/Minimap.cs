using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Transform _player;
    private Transform _cachedTransform;
    
    private void Start()
    {
        _player = Player.player.transform;
        _cachedTransform = transform;
    }
    
    void Update()
    {
        _cachedTransform.position = new Vector3(_player.position.x, _cachedTransform.position.y, _player.position.z);
    }
}
