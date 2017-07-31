using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

	// target impact on game
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{

      Debug.Log("Collision with " + newCollision);
      
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver) {
          Debug.Log("Game is Over!");
          return;
      }
    }

      Debug.Log("Collision object: " + newCollision.gameObject);
      Debug.Log("Collision object tag: " + newCollision.gameObject.tag);
      
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {

        Debug.Log("Target was hit by the projectile");
        
			if (explosionPrefab) {
				// Instantiate an explosion effect at the gameObjects position and rotation
				Instantiate (explosionPrefab, transform.position, transform.rotation);
			}

			// if game manager exists, make adjustments based on target properties
			if (GameManager.gm) {
				GameManager.gm.targetHit (scoreAmount, timeAmount);
			}
				
			// destroy the projectile
			Destroy (newCollision.gameObject);
				
			// destroy self
			Destroy (gameObject);
		}
	}
}
