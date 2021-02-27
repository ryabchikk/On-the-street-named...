using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenuScript : MonoBehaviour
{
    //интерфейс настройки графики
    public Dropdown _dropdown1;
    //интерфейс разрешения экрана
    public Dropdown _dropdown2;
    //массив разрешений экрана
    Resolution[] _resolution;
    void Start()
    {
        _dropdown1.AddOptions(QualitySettings.names.ToList());
        _dropdown1.value = QualitySettings.GetQualityLevel();
        _resolution=Screen.resolutions;
        string[] strRes = new string[_resolution.Length];
        for (int i = 0; i < _resolution.Length; i++) 
        {
            strRes[i] = _resolution[i].ToString();
        }
        _dropdown2.AddOptions(strRes.ToList());

        Screen.SetResolution(_resolution[_resolution.Length-1].width,_resolution[_resolution.Length-1].height,true);
    }
    
    public void SetQualitu() 
    {
        QualitySettings.SetQualityLevel(_dropdown1.value);
    }
    public void SetRes() 
    {
        Screen.SetResolution(_resolution[_dropdown2.value].width, _resolution[_dropdown2.value].height, true);
    }
    public void OnClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
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
