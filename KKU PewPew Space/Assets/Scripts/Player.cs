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

	// En variabel som s�tts i inspektorn, en "bullet"-prefab m�ste dras in i v�rde-f�ltet
	public Bullet bullet;



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
	// vectorn startar som (0.0f, 0.0f)
	private Vector2 position = Vector2.zero;

	// om inget �r skrivet framf�r variabeln kommer kompilatorn anta att den �r private
	// spelaren kommer styra h�ger och v�nster hur h�rt och �t vilket h�ll sparas i den h�r variabeln
	float verticalInput = 0.0f;

	// sidorna p� sk�rmen, vi s�tter variablarna i Start funktionen
	float leftEdge = 0.0f;
	float rightEdge = 0.0f;

	// om spelaren kan skjuta eller inte
	public bool canFire = true;

	// hur m�nga projektiler per sekund
	public float fireRate = 10.0f;

	// ger inspektorn en variabel som ett objekt kan dras in i, p� det s�ttet �r det l�ttare att justera f�r vad som k�nns bra
	public Transform bulletSpawnTransform;

	// Start k�rs en g�ng, innan f�rsta Update framen
	private void Start()
	{
		// s�tter v�rdena h�r
		leftEdge = GameManager.Instance.GetLeftSide();
		rightEdge = GameManager.Instance.GetRightSide();
	}

	// Update k�rs varje frame, det vill s�ga varje g�ng sk�rmen uppdaterar
	private void Update()
	{
		// nollst�ll verticalInput i b�rjan av varje frame
		verticalInput = 0.0f;
		
		// transform.position �r objektets position i spelv�rlden
		position = transform.position;

		// Spelaren ger input f�r h�ger och v�nster som h�mtas och s�tts h�r
		verticalInput = Input.GetAxis("Horizontal");
		
		// Koden i funktionen l�ses uppifr�n och ner
		// s� det spelar roll vilka v�rden som s�tts i vilken ordning

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

		// om h�lsan hamnar under 0 s� har spelaren f�rlorat
		if(health < 0)
		{
			//H�r f�rst�rs objektet "Player" �r p�.
			Destroy(gameObject);
		}
	}

	IEnumerator ShotTimer()
	{
		yield return new WaitForSeconds(1 / fireRate);
		canFire = true;
	}
	// f�r andra skript att �ndra health p� spelaren
	public void AdjustHealth(float amount)
	{
		health += amount;
		
		// "Debug.Log" skriver ut i konsolen i inspektorn, p� det s�ttet �r det l�tt att se om en funktion k�rs och om v�rdena st�mmer �verens
		Debug.Log("The player is healed with: " + amount + " healthpoints."); 
	}
	// funktioner f�r pickups att kalla p�
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
		// om en sk�ld existerar s� anv�nds denna funktion
		// f�r tillf�llet s�nder vi bara ut ett meddelande i inspektorn

		Debug.Log("The shield is trying to increase with: " + amount + " units."); 
	}

}
