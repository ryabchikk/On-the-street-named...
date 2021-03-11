using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] private AudioSource myFx;
	[SerializeField] private AudioClip click;

	public void ClickSound() //событие нажатия кнопки
	{
		myFx.PlayOneShot(click);
	}

}
