using UnityEngine;

public abstract class InteractableBox : MonoBehaviour
{
    [SerializeField] protected bool isReusable;
    [SerializeField] private GameObject hint;
    private GameObject _hint;
    protected float hintHeight = 3f;
    protected bool isAlreadyUsed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _hint = Instantiate(hint, transform.position + Vector3.up * hintHeight, Quaternion.identity);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKey("e"))
            if (isReusable || !isReusable && !isAlreadyUsed)
                OnInteraction();
    }

    private void OnTriggerExit(Collider other) => Destroy(_hint);

    private void OnDestroy() => Destroy(_hint);

    protected abstract void OnInteraction();
}
