using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Lock : MinigameBoard
{
	public static event Action Completed;
	[Header("General")]
	[SerializeField] private InputField inputField; // поле ввода текста
	[SerializeField] private string password; // текущий пароль замка
	[Header("Messages")]
	[SerializeField] private string error;
	[SerializeField] private Color errorColor;
	[SerializeField] private string success;
	[SerializeField] private Color successColor;
	[SerializeField] private string defaultText;
	[SerializeField] private Color defaultColor;
	[Header("Buttons")]
	[SerializeField] private float offset; // расстояние между кнопками
	[SerializeField] private RectTransform button; // объект UI Button 
	[SerializeField] private RectTransform panel; // пустой RectTransform, относительно центра которого, будет построена сетка
	[SerializeField] private LockButton[] allButtons;
	[SerializeField] private Text placeholder;
	private Queue<string> _buttonTexts;
	
	private void Start()
	{
		inputField.interactable = false;
		inputField.characterLimit = password.Length;
		ResetPass();
		SetTextsArray();
		BuildGrid();
	}

	private void SetButtons() // добавление событий для кнопок
	{
		int i = 1;

		foreach (var t in allButtons)
		{
			t.GetComponentInChildren<Text>().text = _buttonTexts.Dequeue();;
			
			switch(i)
			{
				case 10:
					t.SetListener(ResetPass);
					break;
				case 11:
					t.SetListener(() => { AddKeyPass("0"); });
					break;
				case 12:
					t.SetListener(EnterPass);
					break;
				default:
					string number = i.ToString();
					t.SetListener(() => { AddKeyPass(number); });
					break;
			}
			i++;
		}
	}
	
	private void BuildGrid() // создание кнопок
	{
		Vector2 size = new Vector2(button.sizeDelta.x + offset * 2, button.sizeDelta.y + offset);
		
		float posX = -size.x * 3 / 2 - size.x / 2;
		Vector2 pos = new Vector2(posX, Mathf.Abs(posX) - size.y / 2);
		float resetX = posX;
		
		int i = 0;
		allButtons = new LockButton[12];
		
		for(int y = 0; y < 4; y++)
		{
			pos.y -= size.y;
			
			for(int x = 0; x < 3; x++)
			{
				pos.x += size.x;
				
				LockButton newButton = Instantiate(button, panel).GetComponent<LockButton>();
				newButton.Init(new Vector2(pos.x, pos.y), "Button_ID_" + i);
				
				allButtons[i] = newButton;
				i++;
			}
			
			pos.x = resetX;
		}
		SetButtons();
	}

	private void AddKeyPass(string key) 
	{
		if(inputField.text.Length < password.Length)
		{
			inputField.text += key;
		}
	}

	private void EnterPass() 
	{
		if(inputField.text == password)
		{
			OnCompleted();
			Destroy(gameObject);
		}
		else
		{
			SetPlaceholder(error, errorColor);
		}
	}


	private void ResetPass() 
	{
		SetPlaceholder(defaultText, defaultColor);
	}

	private void SetTextsArray()
	{
		_buttonTexts = new Queue<string>();
		for (var i = 0; i < 9; i++)
		{
			_buttonTexts.Enqueue((i + 1).ToString());
		}
		
		_buttonTexts.Enqueue("R");
		_buttonTexts.Enqueue("0");
		_buttonTexts.Enqueue("OK");
	}

	private void SetPlaceholder(string text, Color color)
	{
		inputField.text = string.Empty;
		placeholder.text = text;
		placeholder.color = color;
	}
	
	private static void OnCompleted()
	{
		Completed?.Invoke();
	}
}