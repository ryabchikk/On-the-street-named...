using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Button button;

    public void Init(Vector2 pos, string name)
    {
        rectTransform.anchoredPosition = pos;
        this.name = name;
    }

    public void SetListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }
}
