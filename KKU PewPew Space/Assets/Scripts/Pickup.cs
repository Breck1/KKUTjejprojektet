using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// alla variablar i en enum �r av samma datatyp, kan INTE inneh�lla funktioner
public enum PickupType
{
    // alla variabeltyper �r densamma, s� beh�ver ej specificeras.
    // V�rdena kan inte �ndras efter att skriptet kompilerats
    // v�rdet beh�ver inte specificeras

    NoPickup = 0,
    Health = 1,
    Shield = 2,
    Speed = 3,
    FireShot = 4,
    FrostShot = 5,
    NormalShot = 6,
}

// "RequiredComponent" �r n�got som f�ljer med UnityEngine, det tvingar objektet att ha en viss komponent
[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    // vilken typ av pickup det �r.
    // detta v�rde kan bara vara ett av de som �r definierade i "PickupType"
    public PickupType pickupType = PickupType.NoPickup;

    // en array �r en lista av variablar av samma typ.
    public Sprite[] pickupSprites;

    //referens till SpriteRenderer som m�ste finnas p� objektet
    public SpriteRenderer spriteRenderer;

    public Bullet normalBullet;

    public FlamingBullet flamingBullet;

    // m�nga av pickups kan �ndra ett numeriskt v�rde, detta v�rde beh�ver bara en variabel
    // "Tooltip" �r ett vertyg i UnityEngine, det ger en liten ruta av text i inspektorn n�r pekaren h�lls �ver variabeln
    [Tooltip("The numerical amount the pickup should change, so how much health/speed it should give")]
    public float amount = 10.0f;

    // Om spelaren inte colliderar med pickup-en s� ska den f�rst�ras
    public float lifeTime = 5.0f;
    // Vilket typ av objekt som ska kunna f� en pickup
    public string pickupTag = "Player";

    public float gravityScale = 0.5f;
    // en funktion kan s�tta ett v�rde p� ett argument, om inget v�rde anv�nds kommer argumentet ha v�rdet 10.0f
    public void Init(PickupType pickupType, float amount = 10.0f)
    {
        // om ett argument har samma namn som en variabel i skriptet kommer funktionen anv�nda sig av argumentet
        // f�r att referera variabeln in skriptet anv�nds nyckelordet "this"
        // "this" �r en referens till det egna skriptet.
        this.pickupType = pickupType;
        this.amount = amount;

        // f� referens till SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        
        if ((int)pickupType < pickupSprites.Length)
        {
            // f�r att detta ska fungera s� m�ste bilderna l�ggas i samma ordning som enumen �r skriven
            spriteRenderer.sprite = pickupSprites[(int)pickupType];
        }
    }

	private void Update()
	{
		lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
        // S�kra att den bara interagerar med objekt den ska interagera med
        if(collision.gameObject.CompareTag(pickupTag))
        {
            // referens till spelaren
            Player player = collision.gameObject.GetComponent<Player>();

            // detta �r en "state-machine". En state-machine utf�r en specifik funktion f�r specifika "l�gen" (states).            
		    switch (pickupType)
            {
                case PickupType.Health:
                    player.AdjustHealth(amount);
                    break; 
                case PickupType.Shield:
                    player.AdjustShield(amount);
                    break;
                case PickupType.Speed:
                    player.AdjustSpeed(amount);
                    break;
                case PickupType.FireShot:
                    player.SetBullet(flamingBullet);
                    break;
                case PickupType.FrostShot:
                    // finns bara tv� skott i projektet just nu s� denna g�r ingenting nu. Bara skickar ett meddelande till konsolen
                    Debug.Log("No frostshot Implemented");
                    break;
                case PickupType.NormalShot:
                    player.SetBullet(normalBullet);
                    break;

            }
            // n�r den �r klar s� ska den f�rst�ra sig sj�lv
            Destroy(gameObject);
        }
	}
}
