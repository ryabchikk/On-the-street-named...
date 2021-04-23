using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpscreenNotification : MonoBehaviour
{
    public static UpscreenNotification notificator;
    [SerializeField] private Animator animator;
    [SerializeField] private Text _text;
    private readonly Queue<string> _notifications = new Queue<string>();
    private bool _appearing;

    private void Awake()
    {
        notificator = this;
    }

    private void Update()
    {
        if (_notifications.Count == 0 || _appearing)
            return;

        StartCoroutine(Appear());
    }

    public void Add(string n)
    {
        _notifications.Enqueue(n);
    }

    private IEnumerator Appear()
    {
        _appearing = true;
        
        while (_notifications.Count != 0)
        {
            animator.enabled = true;
            _text.text = _notifications.Dequeue();
            yield return new WaitForSeconds(2.5f);
            animator.enabled = false;
        }
        
        _appearing = false;
    }
}
