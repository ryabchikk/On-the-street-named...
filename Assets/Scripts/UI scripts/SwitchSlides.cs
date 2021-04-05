using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSlides : MonoBehaviour
{
    [SerializeField] private GameObject[] _slides;
    public int _count; 
    void Start(){}
    public void NextSlide() 
    {
        _count++;
        _slides[_count-1].SetActive(false);
        _slides[_count].SetActive(true);
        Debug.Log(_count);
    }
    public void Back() 
    { 
        
    }
    public void StartGame() 
    {
        LoadingManager.Load(3);
    }
}
