using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// v�ran bas projektil, alla andra projektiler kan "�rva" fr�n detta skript
// att "�rva" n�got menas att vi s�ger till kompilatorn att l�sa "f�r�ldern" innan "barnet" (skriptet som �rver)
public class Bullet : MonoBehaviour
{
    // om vi inte skriver 
    public float speed = 10;

    // bullet ska existera f�r en viss tid, annars fylls spelet med objekt som inte anv�nds
    public float lifeTime = 5.0f;

    // Hur mycket skada som g�rs
    public float damage = 10;
    public Rigidbody2D rb;

    // Tag �r ett verktyg som Unity ger oss, det �r ett enkelt s�tt att identifiera objekt i v�rlden via kod
    public string collisionTag = "Enemy";
    // Start k�rs n�r skriptet kommer in i spelv�rlden eller n�r spelet startar (om den b�rjar i spelv�rlden)
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == collisionTag)
        {
            // eftersom vi vill g�ra skada minskar vi h�lsan
            collision.GetComponent<Enemy>().AdjustHealth(-damage);
        }
	}
}
