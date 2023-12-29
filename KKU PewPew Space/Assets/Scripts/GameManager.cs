using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Värden och funktioner som hanterar hela spelet


public class GameManager : MonoBehaviour
{


	// vänster och höger sida på skärmen, de kan sättas i inspektorn
	public float leftEdge = -2.8f;
	public float rightEdge = 2.8f;

	// bara class-en behöver refereras när variabeln är "static"
	public static GameManager Instance;

	//Unity har en "execution order". "Awake" är funktionen som körs först i alla skrip occh körs bara en gång
	private void Awake()
	{

        // objektet som skriptet sitter fast på stannar kvar
		DontDestroyOnLoad(gameObject);
	}

	// "OnEnable" Körs efter "Awake" efter "Awake" körs "Start" som dyker upp i senare skript
	// Alla andra skript kommer börja med "Start" istället för "OnEnable" så att de är garanterade att kalla på denna variabel när den har ett värde
	private void OnEnable()
	{
		Instance = GetComponent<GameManager>();
	}
	// även om det är publika värden så kan det vara dumt att ha andra skript läsa dem direkt, lätt att råka ändra dem av misstag
	public float GetLeftSide()
	{
		return leftEdge;
	}
	public float GetRightSide() 
	{
		return rightEdge;
	}
}
