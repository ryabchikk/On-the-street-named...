using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Text[] textBlocks = new Text[3];
    [SerializeField] private MonoBehaviour[] completeables;
    private ICompleteable[] _completeables;

    private void Start()
    {
        _completeables = new ICompleteable[textBlocks.Length];

        for (var i = 0; i < completeables.Length; i++)
        {
            int j = i;
            _completeables[j] = completeables[j] as ICompleteable;
            _completeables[j].Completed += () => ActivateText(j);
        }
    }

    private void ActivateText(int index)
    {
        UpscreenNotificator.Notify("Информационная панель обновлена");
        Debug.Log(index);
        textBlocks[index].enabled = true;
    }
}
