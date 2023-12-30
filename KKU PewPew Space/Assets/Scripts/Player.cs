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

	// En variabel som sätts i inspektorn, en "bullet"-prefab måste dras in i värde-fältet
	public Bullet bullet;



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
	// vectorn startar som (0.0f, 0.0f)
	private Vector2 position = Vector2.zero;

	// om inget är skrivet framför variabeln kommer kompilatorn anta att den är private
	// spelaren kommer styra höger och vänster hur hårt och åt vilket håll sparas i den här variabeln
	float verticalInput = 0.0f;

	// sidorna på skärmen, vi sätter variablarna i Start funktionen
	float leftEdge = 0.0f;
	float rightEdge = 0.0f;

	// om spelaren kan skjuta eller inte
	public bool canFire = true;

	// hur många projektiler per sekund
	public float fireRate = 10.0f;

	// ger inspektorn en variabel som ett objekt kan dras in i, på det sättet är det lättare att justera för vad som känns bra
	public Transform bulletSpawnTransform;

	// Start körs en gång, innan första Update framen
	private void Start()
	{
		// sätter värdena här
		leftEdge = GameManager.Instance.GetLeftSide();
		rightEdge = GameManager.Instance.GetRightSide();
	}

	// Update körs varje frame, det vill säga varje gång skärmen uppdaterar
	private void Update()
	{
		// nollställ verticalInput i början av varje frame
		verticalInput = 0.0f;
		
		// transform.position är objektets position i spelvärlden
		position = transform.position;

		// Spelaren ger input för höger och vänster som hämtas och sätts här
		verticalInput = Input.GetAxis("Horizontal");
		
		// Koden i funktionen läses uppifrån och ner
		// så det spelar roll vilka värden som sätts i vilken ordning

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

		if (Input.GetButton("Fire1"))
		{
			if(canFire)
			{
				// variabeln "bulletSpawnTransform" flyttas runt i inspektorn. 
				Instantiate(bullet, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
				canFire = false;
				StartCoroutine(ShotTimer());
			}
		}

		// nu flyttar vi spelaren till den nya positionen
		transform.position = position;

		// om hälsan hamnar under 0 så har spelaren förlorat
		if(health < 0)
		{
			//Här förstörs objektet "Player" är på.
			Destroy(gameObject);
		}
	}

	IEnumerator ShotTimer()
	{
		yield return new WaitForSeconds(1 / fireRate);
		canFire = true;
	}
	// för andra skript att ändra health på spelaren
	public void AdjustHealth(float amount)
	{
		health += amount;
		
		// "Debug.Log" skriver ut i konsolen i inspektorn, på det sättet är det lätt att se om en funktion körs och om värdena stämmer överens
		Debug.Log("The player is healed with: " + amount + " healthpoints."); 
	}
	// funktioner för pickups att kalla på
	public void SetBullet(Bullet bullet)
	{
		
		this.bullet = bullet;
		Debug.Log("The player bullet is changed to: " + bullet.name); 
	}
	public void AdjustSpeed(float amount)
	{
		speed += amount;
		Debug.Log("The speed is increased with: " + amount + " units."); 
	}
	public void AdjustShield(float amount)
	{
		// om en sköld existerar så används denna funktion
		// för tillfället sänder vi bara ut ett meddelande i inspektorn

		Debug.Log("The shield is trying to increase with: " + amount + " units."); 
	}

}
