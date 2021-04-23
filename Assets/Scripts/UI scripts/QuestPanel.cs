using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private new RectTransform transform;
    [SerializeField] private GameObject display;
    [SerializeField] private RectTransform start;
    private List<Quest> _quests;

    private void Start()
    {
        _quests = QuestContainer.container.quests;
        

        for (var i = 0; i < _quests.Count; i++)
        {
            var quest = Instantiate(display, transform);
            var questTransform = quest.GetComponent<RectTransform>();
            
            questTransform.anchoredPosition = start.anchoredPosition + Vector2.down * i * questTransform.sizeDelta.y;
            quest.GetComponent<QuestDisplay>().Init(_quests[i]);
        }
    }
}
