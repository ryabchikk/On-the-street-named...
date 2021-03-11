using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private LoadingSlider slider;
    [SerializeField] private GameObject continueButton;
    private AsyncOperation _loading;

    private void Start()
    {
        LoadingManager.OnLoadingScreenLoaded(this);
    }

    public void LoadScene(int newScene)
    {
        if (newScene < 0 || newScene > SceneManager.sceneCountInBuildSettings - 1)
            throw new ArgumentException($"Incorrect new scene index {newScene}");

        StartCoroutine(Load(newScene));
    }
    
    private IEnumerator Load(int newSceneIndex)
    {
        _loading = SceneManager.LoadSceneAsync(newSceneIndex);
        slider.Init(_loading);
        
        _loading.allowSceneActivation = false;

        while (_loading.progress < 0.9f)
        {
            Debug.Log($"Loading {newSceneIndex}, {_loading.progress * 100}%");
            yield return null;
        }

        Debug.Log("Waiting");
        continueButton.SetActive(true);
    }

    //Можно назначить на кнопку
    public void ActivateScene()
    {
        Debug.Log("Activated");
        _loading.allowSceneActivation = true;
    }
}
