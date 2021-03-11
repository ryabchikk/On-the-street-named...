using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[ExecuteInEditMode]
public class Cheats : MonoBehaviour
{
    [SerializeField] private GameObject ladder;
    [SerializeField] private GameObject fpsMeter;
    private bool _cheatsOn;

#if DEBUG
    private void Start()
    {
        _cheatsOn = true;
    }

    private void Update()
    {
        if (_cheatsOn == false) return;

        if (Input.GetKeyDown("d"))
            Instantiate(ladder);
        if(Input.GetKeyDown("f")) 
            fpsMeter.SetActive(fpsMeter.activeInHierarchy == false);
    }
#endif
    //TODO
    private UnityAction ParseCommand(string command)
    {
        throw new NotImplementedException();
    }
}
