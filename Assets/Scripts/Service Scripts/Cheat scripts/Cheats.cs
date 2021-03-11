using System;
using UnityEngine;
using UnityEngine.Events;

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
#endif
    
    private void Update()
    {
        if (_cheatsOn == false) return;

        if (Input.GetKeyDown("l"))
            Instantiate(ladder);
        if(Input.GetKeyDown("f")) 
            fpsMeter.SetActive(fpsMeter.activeInHierarchy == false);
    }

    //TODO
    private UnityAction ParseCommand(string command)
    {
        throw new NotImplementedException();
    }
}
