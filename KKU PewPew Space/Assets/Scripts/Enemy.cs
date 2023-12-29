using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Logiken för enemy
public class Enemy : MonoBehaviour
{
	
	public float speed = 10.0f;
	public float enemyHealth = 100.0f;

	// om fienden ska röra sig åt höger eller vänster.
	int direction = 1;

	// Se player script för en djupare förklaring av vectorer
	// för fiendens position
	Vector2 position = Vector2.zero;
	float horizontalPosition = 0.0f;
	private void Update()
	{
		position = transform.position;
		position.x += speed * Time.deltaTime * direction;
		horizontalPosition = position.x;
		// om fienden är på väg ut från vänster ELLER höger
		if (horizontalPosition <= -2.8f || horizontalPosition >= 2.8f)
		{
			// byter håll på fienden
			direction *= -1;

			// Vänstra sidan av skärmen
			if (horizontalPosition < 0)
			{
				position.x = -2.8f;
			}
			// fienden är utanför på höger sida. 
			else
			{
				position.x = 2.8f;
			}
			
		}

		transform.position = position;
	}
	// en funktion för andra skript att ändra hälsan på.
	public void AdjustHealth(float amount)
	{
		enemyHealth += amount;
	}

}
