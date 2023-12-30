using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Logiken f�r enemy
public class Enemy : MonoBehaviour
{
	
	public float speed = 10.0f;
	public float enemyHealth = 100.0f;

	// "Range" g�r om en variabel till en slider mellan de specificerade talen
	[Range(0.0f, 100.0f)]
	public float dropRate;

	public Pickup pickupPrefab;

	// om fienden ska r�ra sig �t h�ger eller v�nster.
	int direction = 1;

	// Se player script f�r en djupare f�rklaring av vectorer
	// f�r fiendens position
	Vector2 position = Vector2.zero;
	float horizontalPosition = 0.0f;

	// s� l�nge som variabeltypen �r den samma g�r det att sepparera namnen med kommatecken
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
		// om fienden �r p� v�g ut fr�n v�nster ELLER h�ger
		if (horizontalPosition <= leftEdge || horizontalPosition >= rightEdge)
		{
			// byter h�ll p� fienden
			// att skriva: "direction *= -1;" �r detsamma som att skriva "direction = direction * -1"
			direction *= -1;

			// V�nstra sidan av sk�rmen
			if (horizontalPosition < 0)
			{
				position.x = leftEdge;
			}
			// fienden �r utanf�r p� h�ger sida. 
			else
			{
				// s�tter tillbaka v�rdet
				position.x = rightEdge;
			}
			
		}

		transform.position = position;

	
		if (enemyHealth < 0)
		{
			// s� spelaren kan besegra fienden
			OnDeath();
		}
	}
	// en funktion f�r andra skript att �ndra h�lsan p�.
	public void AdjustHealth(float amount)
	{
		enemyHealth += amount;
	}

	// funktionaliteten som h�nder n�r fienden d�r
	void OnDeath()
	{
		// "Random.Range" ger ett random nummer mellan tv� v�rden, 
		float drop = Random.Range(0.0f, 100.0f);

		// om en pickup ska spawnas
		if(drop < dropRate)
		{
			// skapa pickupen i spelv�rlden
			Pickup pickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			
			// Init-funktionen som skapats i Pickup
			pickup.Init((PickupType)Random.Range(1, 6));
		}

		// f�rst�r fienden 
		Destroy(gameObject);
	}

}
