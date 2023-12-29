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

	// så länge som variabeltypen är den samma går det att sepparera namnen med kommatecken
	float leftEdge = 0.0f, rightEdge = 0.0f;

	private void Start()
	{
		rightEdge = GameManager.Instance.GetRightSide();
		leftEdge = GameManager.Instance.GetLeftSide();
	}
	private void Update()
	{
		position = transform.position;
		position.x += speed * Time.deltaTime * direction;
		horizontalPosition = position.x;
		// om fienden är på väg ut från vänster ELLER höger
		if (horizontalPosition <= leftEdge || horizontalPosition >= rightEdge)
		{
			// byter håll på fienden
			// att skriva: "direction *= -1;" är detsamma som att skriva "direction = direction * -1"
			direction *= -1;

			// Vänstra sidan av skärmen
			if (horizontalPosition < 0)
			{
				position.x = leftEdge;
			}
			// fienden är utanför på höger sida. 
			else
			{
				// sätter tillbaka värdet
				position.x = rightEdge;
			}
			
		}

		transform.position = position;

	
		if (enemyHealth < 0)
		{
			// så spelaren kan besegra fienden
			Destroy(gameObject);
		}
	}
	// en funktion för andra skript att ändra hälsan på.
	public void AdjustHealth(float amount)
	{
		enemyHealth += amount;
	}

}
