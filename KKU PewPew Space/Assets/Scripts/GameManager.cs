using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// V�rden och funktioner som hanterar hela spelet


public class GameManager : MonoBehaviour
{


	// v�nster och h�ger sida p� sk�rmen, de kan s�ttas i inspektorn
	public float leftEdge = -2.8f;
	public float rightEdge = 2.8f;

	// bara class-en beh�ver refereras n�r variabeln �r "static"
	public static GameManager Instance;

	//Unity har en "execution order". "Awake" �r funktionen som k�rs f�rst i alla skrip occh k�rs bara en g�ng
	private void Awake()
	{

        // objektet som skriptet sitter fast p� stannar kvar
		DontDestroyOnLoad(gameObject);
	}

	// "OnEnable" K�rs efter "Awake" efter "Awake" k�rs "Start" som dyker upp i senare skript
	// Alla andra skript kommer b�rja med "Start" ist�llet f�r "OnEnable" s� att de �r garanterade att kalla p� denna variabel n�r den har ett v�rde
	private void OnEnable()
	{
		Instance = GetComponent<GameManager>();
	}
	// �ven om det �r publika v�rden s� kan det vara dumt att ha andra skript l�sa dem direkt, l�tt att r�ka �ndra dem av misstag
	public float GetLeftSide()
	{
		return leftEdge;
	}
	public float GetRightSide() 
	{
		return rightEdge;
	}
}
