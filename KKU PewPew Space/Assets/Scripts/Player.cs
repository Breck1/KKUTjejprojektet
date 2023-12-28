using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * H�r skapar vi logiken f�r spelaren
 */
public class Player : MonoBehaviour
{
	// Variablar:
	// float betyder att det �r "flytande" tal, dvs decimaltal, variablarnas v�rden kan s�ttas i Unity
	public float health = 100.0f;
	public float speed = 10.0f;
	public float fireRate = 10.0f;

	// sidorna p� sk�rmen, vi s�tter variablarna i Unity
	public float leftEdge = 0.0f;
	public float rightEdge = 0.0f;

	// Vector2 �r ett s�tt att h�lla tv� nummer samtidigt. Som i ett koordinatsystem
	/* Y
	 * |
	 * |
	 * |		 * (9, 5)
	 * |
	 * |
	 * |
	 * |_______________ X
	 */
	private Vector2 position;

	// om inget �r skrivet framf�r variabeln kommer kompilatorn anta att den �r private
	// vi kommer ta input till h�ger och v�nster fr�n spelaren
	float verticalInput = 0.0f;
	// Update k�rs varje frame, det vill s�ga varje g�ng sk�rmen uppdaterar
	private void Update()
	{
		// nollst�ll verticalInput i b�rjan av varje frame
		verticalInput = 0.0f;
		
		// transform.position �r objektets position i spelv�rlden
		position = transform.position;

		//Vi f�r input f�r h�ger och v�nster
		verticalInput = Input.GetAxis("Horizontal");
		
		// mellan -1 och 1 -1 �r v�nster och 1 �r h�ger
		if (verticalInput != 0 )
		{
							// Time.deltaTime �r tiden mellan f�reg�ende frame och nuvarande frame
			position.x += verticalInput * speed * Time.deltaTime;
			
		
		}
		//om spelaren �r p� v�g utanf�r v�nstra sidan av sk�rmen
		if(position.x < leftEdge)
		{
			// s�tter tillbaka spelaren i sk�rmen
			position.x = leftEdge;

		}

		// spelaren �r p� v�g ut p� h�gra sidan av sk�rmen
		if(position.x > rightEdge)
		{

			// s�tter tillbaka spelaren i sk�rmen
			position.x = rightEdge;
		}

		// nu flyttar vi spelaren till den nya positionen
		transform.position = position;

	}


}
