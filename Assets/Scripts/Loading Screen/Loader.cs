using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float loadingDelay; //Можно убрать
    private AsyncOperation _loading;
    
    void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        _loading = SceneManager.LoadSceneAsync(1);
        _loading.allowSceneActivation = false;
        

        while (_loading.progress < 0.9f)
        {
            slider.value = _loading.progress;
            
            yield return null;
        }

        slider.value = 1;
        yield return new WaitForSeconds(loadingDelay);
        ActivateScene();
    }

    //Можно назначить на кнопку
    private void ActivateScene()
    {
        _loading.allowSceneActivation = true;
    }
}
