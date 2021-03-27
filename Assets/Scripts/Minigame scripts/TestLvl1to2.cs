using System;
using System.Collections.Generic;
using UnityEngine;

public class TestLvl1to2 : TestBoard
{
    [SerializeField] private string question;
    [SerializeField] private string[] answers;

    protected override void Start() { }

    private void OnEnable()
    {
        questionsCount = 1;
        SetQnA();
        InitBlocks();
    }

    protected override void SetQnA()
    {
        Debug.Log("Set");
        answersAll = new[]
        {
            new List<string>(answers)
        };

        questions = new List<string> { question }.GetEnumerator();
    }

    public override void Lose()
    {
        Time.timeScale = 1;
        base.Lose();
    }

    protected override void Success()
    {
        Time.timeScale = 1;
        base.Success();
    }
}
