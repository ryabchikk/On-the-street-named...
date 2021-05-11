using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TestBoard : MinigameBoard
{
    public TestBox box;
    [SerializeField] private GameObject block;
    [SerializeField] private Transform parent;
    [SerializeField] private Question[] _questions;
    protected List<string>[] answersAll;
    protected int questionsCount;
    protected IEnumerator<string> questions;
    private readonly TestBlock[] _blocks = new TestBlock[5];
    private IEnumerator<string> _answersCurr;
    private int _currentQuestion;

    protected virtual void Start()
    {
        questionsCount = _questions.Length;
        SetQnA();
        InitBlocks();
    }

    #region Init

    //Я не смог красиво это расположить на экране
    //В префабе Block можно поменять размер и расположение кнопки чтобы это выглядело нормально
    //Расположение и размер всех кнопок зависит от положения и размера кнопки в префабе
    //Инициализация кнопок, заполнение массива кнопок
    protected void InitBlocks()
    {
        var rt = block.GetComponent<RectTransform>();
        for (int i = 0; i < 5; i++)
        {
            var b = Instantiate(block, parent);
            b.GetComponent<RectTransform>().anchoredPosition = new Vector3(rt.position.x, rt.position.y - i * rt.sizeDelta.y, rt.position.z);
            _blocks[i] = b.GetComponent<TestBlock>();
        }

        //С первой кнопкой взаимодействовать нельзя, в ней текст вопроса
        _blocks[0].GetComponent<Button>().interactable = false;

        //Костыль, без этого не загружается текст
        _blocks[4].Last();
    }

    
    protected virtual void SetQnA()
    {
        answersAll = new List<string>[_questions.Length];
        var l = new List<string>();
        
        for (var i = 0; i < _questions.Length; i++)
        {
            answersAll[i] = new List<string>(_questions[i].answers);
            l.Add(_questions[i].question);
        }

        questions = l.GetEnumerator();
    }

    #endregion

    #region Event Handling
    
    public void NextQuestion()
    {
        if (_currentQuestion < questionsCount)
        {
            _answersCurr = answersAll[_currentQuestion].GetEnumerator();
            questions.MoveNext();
            _blocks[0].text.text = questions.Current;


            foreach (var b in _blocks)
                b.isCorrect = false;

            int rightAnswer = Random.Range(1, 5);
            _blocks[rightAnswer].isCorrect = true;

            foreach (var b in _blocks.Where(n => n.isCorrect == false).Skip(1))
            {
                _answersCurr.MoveNext();
                b.text.text = _answersCurr.Current;
            }
            _answersCurr.MoveNext();
            _blocks[rightAnswer].text.text = _answersCurr.Current;

            _currentQuestion++;
        }
        else
        {
            Success();
        }
    }
    
    //Заглушка
    public virtual void Lose()
    {
        Debug.Log("Lose");
        Destroy(gameObject);
    }

    //Заглушка
    protected virtual void Success()
    {
        box.Success();
        Destroy(gameObject);
    }
    
    #endregion

}
