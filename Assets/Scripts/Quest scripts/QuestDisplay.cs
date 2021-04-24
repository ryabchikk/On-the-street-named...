using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text text;
    [SerializeField] private Toggle toggle;

    public void Init(Quest quest)
    {
        name.text = quest.name;
        text.text = quest.text;
        toggle.isOn = quest.completed;
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
