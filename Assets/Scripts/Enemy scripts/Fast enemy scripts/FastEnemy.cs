using System.Collections;
using UnityEngine;

//Для этого скрипта я написал кастомную коллекцию потому что мне не хотелось писать лишние две строчки кода чтобы враг ходил по кругу
//Также написал очень удобный скрипт редактора который автоматически добавляет таргеты на врага при их создании, подробнее на собрании
public class FastEnemy : MonoBehaviour
{
    [SerializeField] private GameObject parent;  //нужно для работы скрипта редактора
    [SerializeField] private float movingCooldown;  
    [SerializeField] private float speed;
    [SerializeField] private Transform[] targets;  //массив целей
    private CyclicCollection<Transform> _targets;  //массив целей, но другой
    private Player _player;
    private bool _isOnCooldown;
    private Transform _current;  //текущая цель
    
    private void Start()
    {
        _player = Player.player;
        _targets = new CyclicCollection<Transform>(targets);

        ChangeTarget();
        
        if (transform.position != _targets[0].position)
            transform.position = _targets[0].position;
    }

    private void Update()
    {
        if (_isOnCooldown) return;

        Vector3 direction = _current.position - transform.position;
        transform.Translate(speed * Time.deltaTime * direction.normalized);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
            _player.ApplyDamage(4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            ChangeTarget();
            StartCoroutine(Cooldown());
        }

    }

    //уводит врага в кулдаун
    private IEnumerator Cooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSeconds(movingCooldown);
        _isOnCooldown = false;
    }

    //меняет текущую цель
    private void ChangeTarget()
    {
        _targets.MoveNext();
        _current = (Transform)_targets.Current;
    }
}
