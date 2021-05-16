using System;
using UnityEngine;

public abstract class InteractableBox : HintCreatorBase, ICompleteable
{
    public event Action Completed;
    [SerializeField] protected bool isReusable;
    protected float hintHeight = 3f;
    protected bool isAlreadyUsed;
    private GameObject _hint;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKey("e"))
            if (isReusable || !isReusable && !isAlreadyUsed)
                OnInteraction();
    }

    private void OnDestroy()
    {
        Destroy(_hint);
    }
    
    public void OnCompleted()
    {
        Debug.Log($"{name} Completed");
        Completed?.Invoke();
    }

    protected override void OnEnter()
    {
        if(isReusable || !isReusable && !isAlreadyUsed)
            _hint = Instantiate(hint, transform.position + Vector3.up * hintHeight, Quaternion.identity);
    }

    protected override void OnExit()
    {
        Destroy(_hint);
    }

    protected abstract void OnInteraction();
}