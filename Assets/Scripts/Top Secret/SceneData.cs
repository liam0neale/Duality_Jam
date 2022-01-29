using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneData : MonoBehaviour
{
	[Serializable]
	public struct ButtonData
	{
		public Button button;
		public ButtonTypes type;
	}
	
    public List<ButtonData> m_buttons;

	//string[] m_buttonTypesSTR = {"Start", "Options", "Quit"};
	public enum ButtonTypes 
	{
		Start = 0,
		Options = 1,
		Quit = 2
	}

	private void Awake()
	{
		foreach(var bData in m_buttons)
		{
			switch(bData.type)
			{
				case ButtonTypes.Start:
				{
					bData.button.onClick.AddListener(delegate { SceneController.LoadFirstLevel(); });
				}break;
				case ButtonTypes.Options:
				{
					
				}break;
				case ButtonTypes.Quit:
				{
					bData.button.onClick.AddListener(delegate { Application.Quit(); }); 
				}
				break;
				default:
				{
					Debug.LogWarning("SceneData::Awake() -> no case for button type = " + bData.type.ToString());
				}break;
			}
		}
	}
}
