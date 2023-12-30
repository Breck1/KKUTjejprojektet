using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// alla variablar i en enum är av samma datatyp, kan INTE innehålla funktioner
public enum PickupType
{
    // alla variabeltyper är densamma, så behöver ej specificeras.
    // Värdena kan inte ändras efter att skriptet kompilerats
    // värdet behöver inte specificeras

    NoPickup = 0,
    Health = 1,
    Shield = 2,
    Speed = 3,
    FireShot = 4,
    FrostShot = 5,
    NormalShot = 6,
}

// "RequiredComponent" är något som följer med UnityEngine, det tvingar objektet att ha en viss komponent
[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    // vilken typ av pickup det är.
    // detta värde kan bara vara ett av de som är definierade i "PickupType"
    public PickupType pickupType = PickupType.NoPickup;

    // en array är en lista av variablar av samma typ.
    public Sprite[] pickupSprites;

    //referens till SpriteRenderer som måste finnas på objektet
    public SpriteRenderer spriteRenderer;

    public Bullet normalBullet;

    public FlamingBullet flamingBullet;

    // många av pickups kan ändra ett numeriskt värde, detta värde behöver bara en variabel
    // "Tooltip" är ett vertyg i UnityEngine, det ger en liten ruta av text i inspektorn när pekaren hålls över variabeln
    [Tooltip("The numerical amount the pickup should change, so how much health/speed it should give")]
    public float amount = 10.0f;

    // Om spelaren inte colliderar med pickup-en så ska den förstöras
    public float lifeTime = 5.0f;
    // Vilket typ av objekt som ska kunna få en pickup
    public string pickupTag = "Player";

    public float gravityScale = 0.5f;
    // en funktion kan sätta ett värde på ett argument, om inget värde används kommer argumentet ha värdet 10.0f
    public void Init(PickupType pickupType, float amount = 10.0f)
    {
        // om ett argument har samma namn som en variabel i skriptet kommer funktionen använda sig av argumentet
        // för att referera variabeln in skriptet används nyckelordet "this"
        // "this" är en referens till det egna skriptet.
        this.pickupType = pickupType;
        this.amount = amount;

        // få referens till SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        
        if ((int)pickupType < pickupSprites.Length)
        {
            // för att detta ska fungera så måste bilderna läggas i samma ordning som enumen är skriven
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
        // Säkra att den bara interagerar med objekt den ska interagera med
        if(collision.gameObject.CompareTag(pickupTag))
        {
            // referens till spelaren
            Player player = collision.gameObject.GetComponent<Player>();

            // detta är en "state-machine". En state-machine utför en specifik funktion för specifika "lägen" (states).            
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
                    // finns bara två skott i projektet just nu så denna gör ingenting nu. Bara skickar ett meddelande till konsolen
                    Debug.Log("No frostshot Implemented");
                    break;
                case PickupType.NormalShot:
                    player.SetBullet(normalBullet);
                    break;

            }
            // när den är klar så ska den förstöra sig själv
            Destroy(gameObject);
        }
	}
}
