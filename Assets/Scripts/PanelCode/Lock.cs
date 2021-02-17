using System;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MinigameBoard
{
	public static event Action Completed;
	private GameObject player;
	[Header("General")]
	public bool unlock; // переходит в true если замок открыт
	public InputField _InputField; // поле ввода текста
	public string password = "1234"; // текущий пароль замка
	public GameObject[] objectsOn; // массив объектов, которые надо активировать
	public GameObject[] objectsOff; // массив объектов, которые надо деактивировать
	[Header("Messages")]
	public string error = "ОШИБКА";
	public Color errorColor = Color.red;
	public string success = "ПАРОЛЬ ПРИНЯТ";
	public Color successColor = Color.green;
	public string defaultText = "ВВЕДИТЕ ПАРОЛЬ";
	public Color defaultColor = Color.green;
	[Header("Buttons")]
	public float offset = 10; // расстояние между кнопками
	public RectTransform button; // объект UI Button 
	public RectTransform panel; // пустой RectTransform, относительно центра которого, будет построена сетка
	public bool buildButtons; // создание кнопки
	public RectTransform[] allButtons;
	public GameObject lock2D ;
	public GameObject unlock2D ;

	private void Start()
	{
		player = Player.player.gameObject;
		unlock = false;
		_InputField.interactable = false;
		_InputField.characterLimit = password.Length;
		ResetPass();
		
		if(buildButtons) 
			BuildGrid(); 
		else 
			SetButton();

		lock2D = GameObject.Find("NAME").GetComponent<GameObject>();
		unlock2D = GameObject.Find("NAME").GetComponent<GameObject>();
		
	}
	
	private void Update()
	{
		if (unlock == false) return;
		
		lock2D.SetActive(false);
		unlock2D.SetActive(true);
	}


	private void SetButton() // добавление событий для кнопок
	{
		int i = 1;
		foreach (var t in allButtons)
		{
			switch(i)
			{
				case 10:
					t.GetComponentInChildren<Text>().text = "R";
					t.GetComponent<Button>().onClick.AddListener(() => {ResetPass();});
					break;
				case 11:
					t.GetComponentInChildren<Text>().text = "0";
					t.GetComponent<Button>().onClick.AddListener(() => {AddKeyPass("0");});
					break;
				case 12:
					t.GetComponentInChildren<Text>().text = "ОК";
					t.GetComponent<Button>().onClick.AddListener(() => {EnterPass();});
					break;
				default:
					string number = i.ToString();
					t.GetComponentInChildren<Text>().text = number;
					t.GetComponent<Button>().onClick.AddListener(() => {AddKeyPass(number);});
					break;
			}
			i++;
		}
	}
	
	private void BuildGrid() // создание кнопок
	{
		float sizeX = button.sizeDelta.x + offset*2;
		float sizeY = button.sizeDelta.y + offset;
		float posX = -sizeX * 3 / 2 - sizeX / 2;
		float posY = Mathf.Abs(posX) - sizeY / 2;
		float Xreset = posX;
		int i = 0;
		allButtons = new RectTransform[12];
		for(int y = 0; y < 4; y++)
		{
			posY -= sizeY;
			for(int x = 0; x < 3; x++)
			{
				posX += sizeX;
				allButtons[i] = Instantiate(button);
				allButtons[i].SetParent(panel);
				allButtons[i].anchoredPosition = new Vector2(posX, posY);
				allButtons[i].gameObject.name = "Button_ID_" + i;
				i++;
			}
			posX = Xreset;
		}
		SetButton();
		button.gameObject.SetActive(false);
	}

	private void AddKeyPass(string key) 
	{
		if(_InputField.text.Length < password.Length)
		{
			_InputField.text += key;
		}
	}

	private void ClearText()
	{
		_InputField.text = string.Empty;
	}

	private void EnterPass() 
	{
		if(_InputField.text == password)
		{
			foreach(GameObject obj in objectsOn)
			{
				obj.SetActive(true);
			}
			foreach(GameObject obj in objectsOff)
			{
				obj.SetActive(false);
			}

			foreach(RectTransform tr in allButtons)
			{
				// делаем кнопки неактивными, если пароль принят
				tr.GetComponent<Button>().interactable = false;
			}
			
			
			unlock = true;
			ClearText();
			_InputField.placeholder.GetComponent<Text>().text = success;
			_InputField.placeholder.GetComponent<Text>().color = successColor;
			
			OnCompleted();
			Destroy(gameObject);
		}
		else
		{
			ClearText();
			_InputField.placeholder.GetComponent<Text>().text = error;
			_InputField.placeholder.GetComponent<Text>().color = errorColor;
		}
	}


	private void ResetPass() 
	{
		ClearText();
		_InputField.placeholder.GetComponent<Text>().text = defaultText;
		_InputField.placeholder.GetComponent<Text>().color = defaultColor;
	}

	private static void OnCompleted()
	{
		Completed?.Invoke();
	}
}