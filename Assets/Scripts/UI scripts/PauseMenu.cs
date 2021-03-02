using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    private Player _player;
    
    private void Start()
    {
        _player = Player.player;
    }
    public void PauseOn()
    {
        pausePanel.SetActive(true);
        _player.DeactivateShooting();
    }
    public void PauseOff() 
    {
        pausePanel.SetActive(false);
        _player.ActivateShooting();
    }
    public void ExitMainMenu() 
    {
        LoadingManager.Load(0);
    }
}
