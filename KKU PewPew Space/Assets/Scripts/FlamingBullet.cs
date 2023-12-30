using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// en klass kan "�rva" fr�n en annan klass
// variablar och funktioner �r tillg�ngliga i den �rvda klassen
public class FlamingBullet : Bullet
{

	// kommer s�ttas i skriptet
	// denna kula kommer g�ra kontinuerlig skada p� fienden s� d� underl�ttar det att ha en variabel
	Enemy collidingEnemy;

	// override s�ger att funktionen ska k�ras ist�llet f�r den f�r�lder-funktionen
	public override void ApplyDamage(Enemy enemy)
	{
		collidingEnemy = enemy;
	}

	// s� l�nge som projektilen och fienden �verlappar
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(collisionTag))
		{
			// om "collidingEnemy" har ett v�rde
			if (collidingEnemy != null)
			{
				// f�r att g�ra skadan per sekund ist�llet f�r direkt.
				collidingEnemy.AdjustHealth(-damage * Time.deltaTime);


			}
		}
	}
	// n�r fienden och projektilen slutar �verlappa
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag(collisionTag))
		{
			if(collidingEnemy != null)
			{
				// n�r det inte l�ngre kolliderar s� "sl�pps" fienden
				collidingEnemy = null;
			}
		}
	}

}
