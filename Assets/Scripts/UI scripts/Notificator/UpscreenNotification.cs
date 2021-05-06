using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

internal class UpscreenNotification : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Text text;
    private readonly Queue<string> _notifications = new Queue<string>();
    private bool _appearing;

    private void Awake()
    {
        UpscreenNotificator.CreateNotificator(this);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (_notifications.Count == 0 || _appearing)
            return;

        StartCoroutine(Appear());
    }

    public void Notify(string n)
    {
        _notifications.Enqueue(n);
    }

    private IEnumerator Appear()
    {
        _appearing = true;
        
        while (_notifications.Count != 0)
        {
            animator.enabled = true;
            text.text = _notifications.Dequeue();
            yield return new WaitForSeconds(2.5f);
            animator.enabled = false;
        }
        
        _appearing = false;
    }
}