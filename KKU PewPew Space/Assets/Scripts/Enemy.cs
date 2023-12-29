using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Logiken f�r enemy
public class Enemy : MonoBehaviour
{
	
	public float speed = 10.0f;
	public float enemyHealth = 100.0f;

	// om fienden ska r�ra sig �t h�ger eller v�nster.
	int direction = 1;

	// Se player script f�r en djupare f�rklaring av vectorer
	// f�r fiendens position
	Vector2 position = Vector2.zero;
	float horizontalPosition = 0.0f;
	private void Update()
	{
		position = transform.position;
		position.x += speed * Time.deltaTime * direction;
		horizontalPosition = position.x;
		// om fienden �r p� v�g ut fr�n v�nster ELLER h�ger
		if (horizontalPosition <= -2.8f || horizontalPosition >= 2.8f)
		{
			// byter h�ll p� fienden
			direction *= -1;

			// V�nstra sidan av sk�rmen
			if (horizontalPosition < 0)
			{
				position.x = -2.8f;
			}
			// fienden �r utanf�r p� h�ger sida. 
			else
			{
				position.x = 2.8f;
			}
			
		}

		transform.position = position;
	}
	// en funktion f�r andra skript att �ndra h�lsan p�.
	public void AdjustHealth(float amount)
	{
		enemyHealth += amount;
	}

}
