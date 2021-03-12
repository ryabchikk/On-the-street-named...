using System.Linq;
using UnityEngine;
using UnityEditor;

//Сюда лучше не смотреть
[CustomEditor(typeof(FastEnemy))]
public class FastEnemyEditor : Editor
{
    private SerializedProperty _parentProperty;
    private GameObject _parent;
    private SerializedProperty _targets, _speed, _movingCooldown;

    private void OnEnable()
    {
        _parentProperty = serializedObject.FindProperty("parent");

        _parent = (GameObject)_parentProperty.objectReferenceValue;
        _targets = serializedObject.FindProperty("targets");
        _speed = serializedObject.FindProperty("speed");
        _movingCooldown = serializedObject.FindProperty("movingCooldown");
    }

    public override void OnInspectorGUI()
    {
        if (EditorApplication.isPlaying) return;
        Debug.Log("Editor upd");
        serializedObject.Update();
        EditorGUILayout.PropertyField(_speed);
        EditorGUILayout.PropertyField(_movingCooldown);
        EditorGUILayout.PropertyField(_parentProperty);
        EditorGUILayout.PropertyField(_targets);

        var sceneTargets = _parent.GetComponentsInChildren<Transform>().Skip(2).ToArray();
        if (sceneTargets.Count() != _targets.arraySize)
        {
            _targets.ClearArray();

            for (int i = 0; i < sceneTargets.Length; i++)
            {
                _targets.InsertArrayElementAtIndex(i);
                _targets.GetArrayElementAtIndex(i).objectReferenceValue = sceneTargets[i];
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}