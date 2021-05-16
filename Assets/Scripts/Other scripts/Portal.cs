using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private BoxCollider collider;
    [SerializeField] private int sceneIndex;
    public void Open()
    {
        var color = particles.main;
        color.startColor = Color.green;
        collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            LoadingManager.Load(sceneIndex);
    }
}
