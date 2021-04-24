using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private new RectTransform transform;
    [SerializeField] private GameObject display;
    [SerializeField] private RectTransform start;
    private List<Quest> _quests;

    private void OnEnable()
    {
        Player.player.DeactivateShooting();
        _quests = QuestContainer.container.quests;
        

        for (var i = 0; i < _quests.Count; i++)
        {
            var questDisplay = Instantiate(display, transform);
            var questDisplayTransform = questDisplay.GetComponent<RectTransform>();
            
            questDisplayTransform.anchoredPosition = start.anchoredPosition + Vector2.down * i * questDisplayTransform.sizeDelta.y;
            questDisplay.GetComponent<QuestDisplay>().Init(_quests[i]);
        }
    }

    private void OnDisable()
    {
        Player.player.ActivateShooting();
    }
}
