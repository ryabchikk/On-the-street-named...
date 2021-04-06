using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] GameObject _questionBoard;
    [SerializeField] GameObject _closeMapButton;
    [SerializeField] GameObject _articlesBoard;
    public void OpenMap() 
    {
        _questionBoard.SetActive(false);
        _closeMapButton.SetActive(true);
    }
    public void CloseMap() 
    {
        _questionBoard.SetActive(true);
        _closeMapButton.SetActive(false);
    }
    public void OpenArticles() 
    {
        _articlesBoard.SetActive(true);
    }
}
