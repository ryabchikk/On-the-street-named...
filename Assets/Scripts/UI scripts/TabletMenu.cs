using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletMenu : MonoBehaviour
{
    [SerializeField] private GameObject _tabletPanel;
    private Player _player;
    void Start()
    {
        _player = Player.player;
    }

    public void tabletOn()
    {
        _player.DeactivateShooting();
        _tabletPanel.SetActive(true);
    }
    public void tabletOff()
    {
        _player.ActivateShooting();
        _tabletPanel.SetActive(false);
    }
}
