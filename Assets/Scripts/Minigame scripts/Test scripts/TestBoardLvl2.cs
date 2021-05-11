using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoardLvl2 : TestBoard
{
    [SerializeField] private new Question[] questions;

    protected override void Start()
    {
        questionsCount = questions.Length;
        base.Start();
    }

    protected override void SetQnA()
    {
        answersAll = new List<string>[questions.Length];
        
        for (var i = 0; i < questions.Length; i++)
        {
            answersAll[i] = new List<string>(questions[i].answers);
            base.questions = new List<string> {questions[i].question}.GetEnumerator();
        }
    }
}
