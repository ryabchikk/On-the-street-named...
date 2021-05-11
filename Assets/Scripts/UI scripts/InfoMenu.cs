using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject[] otherPanels;
    private Player _player;
    
    private void Start()
    {
        _player = Player.player;
    }
    public void InfoOn() 
    {
        _player.DeactivateShooting();
        for (int i = 0; i < otherPanels.Length; i++) 
        {
            otherPanels[i].SetActive(false);
        }
        infoPanel.SetActive(true);
    }
    public void InfoOff()
    {
        _player.ActivateShooting();
        infoPanel.SetActive(false);
    }
}
