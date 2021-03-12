using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HintCreatorBase : MonoBehaviour
{
    [SerializeField] protected GameObject hint;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            OnEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit();
    }

    protected abstract void OnEnter();

    protected abstract void OnExit();
}
