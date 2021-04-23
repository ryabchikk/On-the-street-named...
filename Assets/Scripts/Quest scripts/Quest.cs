using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class Quest
{
    public Quest()
    {
        name = "Default name";
        text = "Default text";
        target = null;
    }

    [SerializeField] public string name;
    [SerializeField] public string text;
    public MonoBehaviour target;
    private ICompleteable _target;

    public void Init()
    {
        _target = (ICompleteable)target;
        _target.Completed += OnQuestCompleted;
    }

    private void OnQuestCompleted()
    {
        throw new NotImplementedException();
    }
}