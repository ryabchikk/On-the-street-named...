using UnityEngine;

public class SubmitButton : MonoBehaviour
{
    private Board _board;
    private KakuroBox _kakuroBox;
    
    void Start()
    {
        _kakuroBox = KakuroBox.kakuroBox;
        _board = GameObject.FindWithTag("Board").GetComponent<Board>();
    }
    
    private void Click()
    {
        if (_board.CheckSums())
        {
            _kakuroBox.OnCompleted();
            Destroy(_board.gameObject);
        }
        else 
        { 
            _board.WrongNumbers();
        }
    }
}


