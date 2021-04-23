using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text text;

    public void Init(Quest quest)
    {
        name.text = quest.name;
        text.text = quest.text;
    }
}
