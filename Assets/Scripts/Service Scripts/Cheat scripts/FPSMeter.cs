using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSMeter : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(CountFps());
    }

    private IEnumerator CountFps()
    {
        while (true)
        {
            text.text = $"{Mathf.Round(1 / Time.deltaTime)} FPS";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
