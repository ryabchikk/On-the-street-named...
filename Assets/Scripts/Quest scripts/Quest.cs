using System;
using UnityEngine;

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
    public bool completed;
    private ICompleteable _target;
    private QuestDisplay _display;

    public void Init()
    {
        _target = (ICompleteable)target;
        _target.Completed += OnQuestCompleted;
        completed = false;
    }

    public void SetDisplay(QuestDisplay display)
    {
        _display = display;
    }

    private void OnQuestCompleted()
    {
        UpscreenNotification.notificator.Add("Журнал заданий обновлен");
        completed = true;
    }
}