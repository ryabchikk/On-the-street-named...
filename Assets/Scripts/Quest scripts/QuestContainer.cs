using System.Collections.Generic;
using UnityEngine;

public class QuestContainer : MonoBehaviour
{
#if UNITY_EDITOR
    [ReadOnly]
#endif
    public List<Quest> quests = new List<Quest>();
   
    public static QuestContainer container;

    private void Awake()
    {
        container = this;
        foreach (var quest in quests)
            quest.Init();
    }
    
    public void Add(Quest quest)
    {
        quests.Add(quest);
    }

    public void Remove(Quest quest)
    {
        quests.Remove(quest);
    }
    
#if UNITY_EDITOR
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