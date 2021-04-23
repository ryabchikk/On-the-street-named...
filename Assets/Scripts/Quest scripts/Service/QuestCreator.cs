#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class QuestCreator : EditorWindow
{
    public QuestContainer caller;
    private Quest _quest = new Quest();
    private string _name = "";
    private string _text = "";
    private MonoBehaviour _obj;
    private ICompleteable _objective;
    
    private void OnGUI()
    {
        _quest = QuestDrawer.Draw(_quest);
        
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        if(GUILayout.Button("Add"))
        {
            if (_quest.target == null)
                return;

            caller.Add(_quest);
            Close();
        }
    }
}
#endif