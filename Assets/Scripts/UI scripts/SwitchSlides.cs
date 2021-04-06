using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSlides : MonoBehaviour
{
    [SerializeField] private GameObject[] _slides;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _prevButton;
    [SerializeField] private GameObject _slidesBoard;
    public int _count; 
    void Start(){}
    public void NextSlide() 
    {
        _count++; 
        _slides[_count-1].SetActive(false);
        _slides[_count].SetActive(true);
        if (_count == _slides.Length-1) 
        {
            _nextButton.SetActive(false);
        }
        if (_count == 1)
        {
            _prevButton.SetActive(true);
        }
        Debug.Log(_count);
    }
    public void PrevSlide() 
    {
        _count--;
        _prevButton.SetActive(true);
        _slides[_count + 1].SetActive(false);
        _slides[_count].SetActive(true);
        if (_count == 0)
        {
            _prevButton.SetActive(false);
        }
        if (_count == _slides.Length - 2) 
        {
            _nextButton.SetActive(true);
        }
        Debug.Log(_count);
    }
    public void CloseSlides() 
    {
        _slidesBoard.SetActive(false);
    }
    public void StartGame() 
    {
        LoadingManager.Load(3);
    }
}
