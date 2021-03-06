using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bestiaryMenu : MonoBehaviour
{
    [SerializeField] private GameObject bestiaryPanel;
    [SerializeField] private GameObject[] otherPanels;
    private Player _player;
    private void Start()
    {
        _player = Player.player;
    }
    public void BestiaryOn() 
    {
        _player.DeactivateShooting();
        for (int i = 0; i < otherPanels.Length; i++)
        {
            otherPanels[i].SetActive(false);
        }
        bestiaryPanel.SetActive(true);
    }
    public void BestiaryOff()
    {
        bestiaryPanel.SetActive(false);
        _player.ActivateShooting();
    }
}
