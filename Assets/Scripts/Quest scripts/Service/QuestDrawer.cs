using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class QuestDrawer
{
    public static Quest Draw(Quest quest)
    {
        quest.name = EditorGUILayout.TextField("Quest name", quest.name);

        EditorGUILayout.Separator();

        quest.text = EditorGUILayout.TextField("Quest text", quest.text);

        EditorGUILayout.Separator();

        quest.target = EditorGUILayout.ObjectField("Objective", quest.target, typeof(MonoBehaviour), true) as MonoBehaviour;
        Validate(quest);

        return quest;
    }
    
    private static void Validate(Quest quest)
    {
        if (quest.target is ICompleteable == false)
            quest.target = null;
    }
}