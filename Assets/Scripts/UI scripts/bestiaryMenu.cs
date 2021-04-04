using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestiaryMenu : MonoBehaviour
{
    [SerializeField] private GameObject bestiaryPanel;
    private Player _player;
    private void Start()
    {
        _player = Player.player;
    }
    public void BestiaryOn() 
    {
        _player.DeactivateShooting();
        bestiaryPanel.SetActive(true);
    }
    public void BestiaryOff()
    {
        bestiaryPanel.SetActive(false);
        _player.ActivateShooting();
    }
}
