using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CheckersBlock : MonoBehaviour
{
    public enum State
    {
        Black,
        White,
        Empty
    }
    
    public RectTransform transform;
    [HideInInspector] public State state;
    [SerializeField] private Image sprite;
    private CheckersBoard _board;
    private int _order;
    private List<int> _visitedPositions;

    private Dictionary<Color, State> _states = new Dictionary<Color, State>
    {
        {Color.black, State.Black},
        {Color.white, State.White},
        {Color.clear, State.Empty}
    };
    
    public Button Button { get; private set; }

    public void Init(int order, Color color, CheckersBoard board)
    {
        Button = GetComponent<Button>();
        transform.anchoredPosition += new Vector2(order * transform.sizeDelta.x, 0);
        _order = order;
        _board = board;
        sprite.color = color;
        state = _states[color];
        _visitedPositions = new List<int> {_order};
    }

    public void SetOrder(int order)
    {
        _order = order;
        _visitedPositions.Add(order);
    }

    public bool IsVisited(int position)
    {
        foreach (var visitedPosition in _visitedPositions)
        {
            if (visitedPosition == position)
                return true;
        }

        return false;
    }

    public void OnClick()
    {
        if(state == State.Empty)
            OnClickEmpty();
        else
            OnClickNotEmpty();
    }

    private void OnClickEmpty()
    {
        _board.SwapButtons();
    }
    
    private void OnClickNotEmpty()
    {
        _board.Select(_order);
    }
}
