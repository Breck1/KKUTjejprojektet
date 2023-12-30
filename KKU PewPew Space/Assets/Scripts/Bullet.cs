using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// våran bas projektil, alla andra projektiler kan "ärva" från detta skript
// att "ärva" något menas att vi säger till kompilatorn att läsa "föräldern" innan "barnet" (skriptet som ärver)
public class Bullet : MonoBehaviour
{
    // om vi inte skriver 
    public float speed = 10;

    // bullet ska existera för en viss tid, annars fylls spelet med objekt som inte används
    public float lifeTime = 5.0f;

    // Hur mycket skada som görs
    public float damage = 10;
    public Rigidbody2D rb;

    // Tag är ett verktyg som Unity ger oss, det är ett enkelt sätt att identifiera objekt i världen via kod
    public string collisionTag = "Enemy";
    // Start körs när skriptet kommer in i spelvärlden eller när spelet startar (om den börjar i spelvärlden)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // livstiden för objektet minskas varje frame
        lifeTime -= Time.deltaTime;

        // om livstiden är under 0 så ska objektet förstöras
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == collisionTag)
        {
            // eftersom "bullet" gör skada så är ändringen negativ
            ApplyDamage(collision.GetComponent<Enemy>());
        }
	}
    // "virtual" meddelar kompilatorn att en funktion kan bli överskriven av en funktion i en klass som ärver från denna klass
    public virtual void ApplyDamage(Enemy enemy)
    {
        enemy.AdjustHealth(-damage);
    }
}
