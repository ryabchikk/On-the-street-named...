#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestContainer))]
public class QuestContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.BeginHorizontal();
        
        if (GUILayout.Button("Add quest", GUILayout.MaxWidth(175)))
            EditorWindow
                .GetWindowWithRect<QuestCreator>(new Rect(500, 500, 350, 130))
                .caller = target as QuestContainer;

        if (GUILayout.Button("Edit quests", GUILayout.MaxWidth(175)))
            EditorWindow.GetWindow<QuestsEditor>().Init(target as QuestContainer);
        
        EditorGUILayout.EndHorizontal();
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif