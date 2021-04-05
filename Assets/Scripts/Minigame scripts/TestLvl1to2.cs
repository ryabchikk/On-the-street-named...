using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLvl1to2 : TestBoard
{
    [SerializeField] private string question;
    [SerializeField] private string[] answers;
    private Waypoint _waypoint;

    protected new void Awake()
    {
        Time.timeScale = 0;
    }

    protected new void OnDestroy()
    {
        Time.timeScale = 1;
    }
    protected override void Start() { }

    private void OnEnable()
    {
        questionsCount = 1;
        SetQnA();
        InitBlocks();
    }

    public void Init(Waypoint wp)
    {
        _waypoint = wp;
    }

    protected override void SetQnA()
    {
        answersAll = new[]
        {
            new List<string>(answers)
        };

        questions = new List<string> { question }.GetEnumerator();
    }

    public override void Lose()
    {
        SceneManager.LoadScene(4);
        base.Lose();
    }

    protected override void Success()
    {
        _waypoint.NextQuestion();
        gameObject.SetActive(false);
    }
}
