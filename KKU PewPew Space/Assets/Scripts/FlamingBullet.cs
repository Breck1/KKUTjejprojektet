using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// en klass kan "ärva" från en annan klass
// variablar och funktioner är tillgängliga i den ärvda klassen
public class FlamingBullet : Bullet
{

	// kommer sättas i skriptet
	// denna kula kommer göra kontinuerlig skada på fienden så då underlättar det att ha en variabel
	Enemy collidingEnemy;

	// override säger att funktionen ska köras istället för den förälder-funktionen
	public override void ApplyDamage(Enemy enemy)
	{
		collidingEnemy = enemy;
	}

	// så länge som projektilen och fienden överlappar
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(collisionTag))
		{
			// om "collidingEnemy" har ett värde
			if (collidingEnemy != null)
			{
				// för att göra skadan per sekund istället för direkt.
				collidingEnemy.AdjustHealth(-damage * Time.deltaTime);


			}
		}
	}
	// när fienden och projektilen slutar överlappa
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag(collisionTag))
		{
			if(collidingEnemy != null)
			{
				// när det inte längre kolliderar så "släpps" fienden
				collidingEnemy = null;
			}
		}
	}

}
