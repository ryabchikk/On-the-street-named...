using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject Player;
    private ShootingScript ShootActivation;
    private void Start()
    {
        ShootActivation = Player.GetComponent<ShootingScript>();
    }
    public void PauseOn()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        ShootActivation.enabled = false;
    }
    public void PauseOff() 
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        ShootActivation.enabled = true;
    }
    public void ExitMainMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
