using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestsEditor : EditorWindow
{
    private List<Foldout<Quest>> _foldouts;
    private QuestContainer _caller;

    public void Init(QuestContainer caller)
    {
        _foldouts = new List<Foldout<Quest>>();
        _caller = caller;
        
        foreach (var quest in caller.quests)
            _foldouts.Add(new Foldout<Quest>(quest));
    }

    private void OnGUI()
    {
        int i = 0;
        while(i < _foldouts.Count)
        {
            var quest = _foldouts[i];
            EditorGUILayout.BeginHorizontal();
            
            quest.state = EditorGUILayout.BeginFoldoutHeaderGroup(quest.state, quest.value.name);
            if(quest.state == false)
            {
                DrawRemoveButton(quest);
            }
            
            EditorGUILayout.EndHorizontal();

            if(quest.state)
            {
                QuestDrawer.Draw(quest.value);
                
                EditorGUILayout.BeginHorizontal();
                
                EditorGUILayout.LabelField("");
                DrawRemoveButton(quest);
                
                EditorGUILayout.EndHorizontal();
                
                EditorGUILayout.Separator();
                EditorGUILayout.Separator();
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            i++;
        }
    }

    private void DrawRemoveButton(Foldout<Quest> quest)
    {
        if (GUILayout.Button("Remove", GUILayout.MaxWidth(100)))
        {
            _caller.Remove(quest.value);
            _foldouts.Remove(quest);
        }
    }
}

public class Foldout<T>
{
    public readonly T value;
    public bool state;

    public Foldout(T v)
    {
        value = v;
        state = false;
    }
}