using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Serialization;

public class TestBoard : MonoBehaviour
{
    
    [SerializeField] private GameObject block;
    [SerializeField] private Transform parent;
    private readonly TestBlock[] _blocks = new TestBlock[5];
    private const int QuestionsCount = 4;
    private IEnumerator<string> _answersCurr;
    private List<string>[] _answersAll;
    private IEnumerator<string> _questions;
    private int _currentQuestion;
    private Player _player;
    
    void Start()
    {
        _player = Player.player;
        SetQnA();
        InitBlocks();
    }

    #region Init

    //Я не смог красиво это расположить на экране
    //В префабе Block можно поменять размер и расположение кнопки чтобы это выглядело нормально
    //Расположение и размер всех кнопок зависит от положения и размера кнопки в префабе
    //Инициализация кнопок, заполнение массива кнопок
    private void InitBlocks()
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

    
    private void SetQnA()
    {
        _answersAll = new[]
        {
            new List<string> { "Япония", "Германия", "Узбекистан", "Азербайджан" },
            new List<string> { "Инженер", "Разведчик", "Военный врач", "Журналист" },
            new List<string> { "Джек", "Дора", "Кент", "Рамзай" },
            new List<string> { "1941", "1944", "Не присвоено", "1964" },
        };
        _questions = new List<string> { "Зорге родился:", "По образованию был:", "Псевдоним:", "Когда было присвоено звание героя советского союза?" }.GetEnumerator();
    }

    #endregion

    #region Event Handling
    
    public void NextQuestion()
    {
        if (_currentQuestion < QuestionsCount)
        {
            _answersCurr = _answersAll[_currentQuestion].GetEnumerator();
            _questions.MoveNext();
            _blocks[0].text.text = _questions.Current;


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
    public void Lose()
    {
        Debug.Log("Lose");
        Destroy(gameObject);
        _player.ActivateShooting();
        
    }

    //Заглушка
    private void Success()
    {
        Debug.Log("Success");
        Destroy(gameObject);
        _player.ActivateShooting();
    }
    
    #endregion

}
