using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using State = CheckersBlock.State;

public class CheckersBoard : MinigameBoard
{
    [SerializeField] private RectTransform canvas;
    [SerializeField] private GameObject blockPrefab;
    private CheckersBlock[] _blocks;
    private int _emptyIndex;
    private int _selectedIndex;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _blocks = new CheckersBlock[9];
        _emptyIndex = 4;
        _selectedIndex = -1;
        
        for (int i = 0; i < 9; i++)
        {
            var block = Instantiate(blockPrefab, canvas).GetComponent<CheckersBlock>();
            
            block.Init(i, i < 4 ? Color.black : i > 4 ? Color.white : Color.clear, this);
            _blocks[i] = block;
            _blocks[i].Button.interactable = false;
        }

        for (int i = 1; i < 3; i++)
        {
            if (_emptyIndex + i < 9)
                _blocks[_emptyIndex + i].Button.interactable = true;
        }
    }

    private void UpdateButtons()
    {
        foreach (var block in _blocks)
        {
            block.Button.interactable = false;
        }

        for (int i = 1; i < 3; i++)
        {
            if (_emptyIndex + i < 9)
                _blocks[_emptyIndex + i].Button.interactable = true;
            if (_emptyIndex - i > -1)
                _blocks[_emptyIndex - i].Button.interactable = true;
        }
    }

    public void Select(int index)
    {
        _selectedIndex = index;
        
        foreach (var block in _blocks)
        {
            block.Button.interactable = false;
        }

        if(_blocks[_selectedIndex].IsVisited(_emptyIndex) == false)
            _blocks[_emptyIndex].Button.interactable = true;
    }

    public void Deselect()
    {
        UpdateButtons();
        _selectedIndex = -1;
    }

    public void SwapButtons()
    {
        if (_selectedIndex == -1)
            throw new ArgumentException("Block is not selected");
        
        UpdateSwappedButtons(_selectedIndex, _emptyIndex);
        SwapInArray(_selectedIndex, _emptyIndex);
        
        UpdateButtons();
        if (CheckVictory())
        {
            Debug.Log("Victory");
            StartCoroutine(Victory());
        }
    }

    public void ResetBoard()
    {
        foreach (var block in _blocks)
        {
            Destroy(block.gameObject);
        }
        
        Init();
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(3f);
        CheckersBox.checkersBox.OnCompleted();
        Destroy(gameObject);
    }

    private void SwapInArray(int selected, int empty)
    {
        var t = _blocks[selected];
        _blocks[selected] = _blocks[empty];
        _blocks[empty] = t;
        
        _emptyIndex = _selectedIndex;
        _selectedIndex = -1;
    }

    private void UpdateSwappedButtons(int selected, int empty)
    {
        var position = _blocks[selected].transform.anchoredPosition;
        _blocks[selected].transform.anchoredPosition = _blocks[empty].transform.anchoredPosition;
        _blocks[empty].transform.anchoredPosition = position;
        
        _blocks[empty].SetOrder(selected);
        _blocks[selected].SetOrder(empty);
    }

    private bool CheckVictory()
    {
        for (int i = 0; i < 4; i++)
        {
            if (_blocks[i].state != State.White)
                return false;
        }

        for (int i = 6; i < 9; i++)
        {
            if (_blocks[i].state != State.Black)
                return false;
        }

        return true;
    }
}