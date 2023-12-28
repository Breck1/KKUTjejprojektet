using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Här skapar vi logiken för spelaren
 */
public class Player : MonoBehaviour
{
	// Variablar:
	// float betyder att det är "flytande" tal, dvs decimaltal, variablarnas värden kan sättas i Unity
	public float health = 100.0f;
	public float speed = 10.0f;
	public float fireRate = 10.0f;

	// sidorna på skärmen, vi sätter variablarna i Unity
	public float leftEdge = 0.0f;
	public float rightEdge = 0.0f;

	// Vector2 är ett sätt att hålla två nummer samtidigt. Som i ett koordinatsystem
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

	// om inget är skrivet framför variabeln kommer kompilatorn anta att den är private
	// vi kommer ta input till höger och vänster från spelaren
	float verticalInput = 0.0f;
	// Update körs varje frame, det vill säga varje gång skärmen uppdaterar
	private void Update()
	{
		// nollställ verticalInput i början av varje frame
		verticalInput = 0.0f;
		
		// transform.position är objektets position i spelvärlden
		position = transform.position;

		//Vi får input för höger och vänster
		verticalInput = Input.GetAxis("Horizontal");
		
		// mellan -1 och 1 -1 är vänster och 1 är höger
		if (verticalInput != 0 )
		{
							// Time.deltaTime är tiden mellan föregående frame och nuvarande frame
			position.x += verticalInput * speed * Time.deltaTime;
			
		
		}
		//om spelaren är på väg utanför vänstra sidan av skärmen
		if(position.x < leftEdge)
		{
			// sätter tillbaka spelaren i skärmen
			position.x = leftEdge;

		}

		// spelaren är på väg ut på högra sidan av skärmen
		if(position.x > rightEdge)
		{

			// sätter tillbaka spelaren i skärmen
			position.x = rightEdge;
		}

		// nu flyttar vi spelaren till den nya positionen
		transform.position = position;

	}


}
