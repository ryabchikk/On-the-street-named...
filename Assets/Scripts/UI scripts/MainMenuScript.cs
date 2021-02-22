using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenuScript : MonoBehaviour
{
    public Dropdown _dropdown;
    void Start()
    {
        _dropdown.AddOptions(QualitySettings.names.ToList());
        _dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void SetQualitu() 
    {
        QualitySettings.SetQualityLevel(_dropdown.value);
    }
    public void OnClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void OnclickExit()
    {
        Application.Quit();
    }
    public void OnclickShowPanel(GameObject obj) 
    {
        obj.SetActive(true);
    }
    public void OnclickHidePanel(GameObject obj) 
    {
        obj.SetActive(false);
    }
}
