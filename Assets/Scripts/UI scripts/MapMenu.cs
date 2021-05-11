using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject[] otherPanels;
    private Player _player;
    private void Start()
    {
        _player = Player.player;
    }
    public void MapOn()
    {

        _player.DeactivateShooting();
        for (int i = 0; i < otherPanels.Length; i++)
        {
            otherPanels[i].SetActive(false);
        }
        mapPanel.SetActive(true);
    }
}
