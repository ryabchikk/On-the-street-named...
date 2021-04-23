using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class QuestContainer : MonoBehaviour
{
    [ReadOnly, SerializeField] public List<Quest> quests = new List<Quest>();

    private void Start()
    {
        foreach (var quest in quests)
        {
            quest.Init();
        }
    }
    
#if UNITY_EDITOR
    public void Add(Quest quest)
    {
        quests.Add(quest);
    }

    public void Remove(Quest quest)
    {
        quests.Remove(quest);
    }
    
    private void OnValidate()
    {
        if (quests.Count == 0 || quests == null)
            return;
        
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i] == null || quests[i].target == null)
            {
                quests.Remove(quests[i]);
            }
        }
    }
#endif
}