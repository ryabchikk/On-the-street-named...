using System;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public event Action Completed;
    [SerializeField] private GameObject[] test;
    private IEnumerator<GameObject> _enumerator;

    private void Start()
    {
        _enumerator = ((IEnumerable<GameObject>)test).GetEnumerator();
    }

    private void OnTriggerEnter(Collider other)
    {
        NextQuestion();
    }

    public void NextQuestion()
    {
        if(_enumerator.MoveNext())
        {
            _enumerator.Current.SetActive(true);
            _enumerator.Current.GetComponent<TestLvl1to2>().Init(this);
        }
        else
        {
            Time.timeScale = 1;
            Completed?.Invoke();
        }
    }
}
