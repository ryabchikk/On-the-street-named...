using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    private Image _image;
    
    private void OnEnable()
    {
        _image = GetComponent<Image>();
        StartCoroutine(FadeIn(fadeTime));
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator FadeIn(float time)
    {
        float alpha = 0;
        while(alpha < 1)
        {
            _image.color = new Color(1, 1, 1, alpha);
            alpha += 0.01f;
            yield return new WaitForSeconds(time / 100);
        }
    }
}
