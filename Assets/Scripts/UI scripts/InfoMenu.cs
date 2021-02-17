using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    private Player _player;
    
    private void Start()
    {
        _player = Player.player;
    }
    public void InfoOn() 
    {
        _player.DeactivateShooting();
        infoPanel.SetActive(true);
    }
    public void InfoOff()
    {
        _player.ActivateShooting();
        infoPanel.SetActive(false);
    }
}
