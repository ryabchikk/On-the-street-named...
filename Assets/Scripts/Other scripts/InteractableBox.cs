using System;
using System.Collections;
using UnityEngine;

public abstract class InteractableBox : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    private GameObject _hint;
    protected float hintHeight = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _hint = Instantiate(hint, transform.position + Vector3.up * hintHeight, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(_hint);
    }

    private void OnDestroy()
    {
        Destroy(_hint);
    }
}
