#if UNITY_EDITOR
using System.Linq;
using UnityEngine;
using UnityEditor;

//Сюда лучше не смотреть
[CustomEditor(typeof(FastEnemy))]
public class FastEnemyEditor : Editor
{
    private SerializedProperty _parentProperty;
    private GameObject _parent;
    private SerializedProperty _targets;

    private void OnEnable()
    {
        _parentProperty = serializedObject.FindProperty("parent");

        _parent = (GameObject)_parentProperty.objectReferenceValue;
        _targets = serializedObject.FindProperty("targets");
    }

    public override void OnInspectorGUI()
    {
        if (EditorApplication.isPlaying) return;
        DrawDefaultInspector();

        var sceneTargets = _parent.GetComponentsInChildren<Transform>()
            .Where(x => x.gameObject.CompareTag("Target"))
            .ToArray();
        
        if (sceneTargets.Length != _targets.arraySize)
        {
            _targets.ClearArray();

            for (int i = 0; i < sceneTargets.Length; i++)
            {
                if (sceneTargets[i] is RectTransform) continue;
                _targets.InsertArrayElementAtIndex(i);
                _targets.GetArrayElementAtIndex(i).objectReferenceValue = sceneTargets[i];
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif