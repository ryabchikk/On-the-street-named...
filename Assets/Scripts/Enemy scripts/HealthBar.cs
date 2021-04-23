using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSliderBase primarySlider;
    [SerializeField] private HealthSliderBase secondarySlider;
    private IDamageable _target;
    private Transform _camera;
    private bool _slidersAreActive;

    private void Start()
    {
        _camera = Camera.main.transform;

        _target = GetComponentInParent<IDamageable>();
        
        primarySlider.Init(_target.Health);
        secondarySlider.Init(_target.Health);
        
        _target.DamageApplied += ChangeSliders;
        
        primarySlider.gameObject.SetActive(false);
        secondarySlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.LookAt(_camera);
    }

    private void ChangeSliders(int amount)
    {
        if (_slidersAreActive == false)
        {
            primarySlider.gameObject.SetActive(true);
            secondarySlider.gameObject.SetActive(true);
            _slidersAreActive = true;
        }
        
        secondarySlider.Change(_target.Health);
        primarySlider.Change(_target.Health);
    }
}
