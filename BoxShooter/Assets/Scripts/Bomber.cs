using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomber : MonoBehaviour {

    public GameObject explosionPrefab;
    
    private GameManager gm;
    
    private Text countDownUIText;
    private float timeTillExplosion = 5f;
    
    // Use this for initialization
    void Start () {
        gm = GameManager.gm;

        gm.countDownUI.SetActive(true);

        countDownUIText = gm.countDownUI.GetComponent<Text>();
        countDownUIText.text = timeTillExplosion.ToString();
    }
  
    // Update is called once per frame
    void Update () {
        float updatedTime = timeTillExplosion - Time.deltaTime;

        if (updatedTime <= 0.0) {
            countDownUIText.text = "0.00";
            GameManager.gm.EndGame();
        } else {
            timeTillExplosion = updatedTime;
            countDownUIText.text = timeTillExplosion.ToString("0.00");
        }
    }
    
    void OnCollisionEnter (Collision newCollision) {
        if (GameManager.gm && GameManager.gm.gameIsOver) {
            Debug.Log("Game is Over!");
            return;
        }

        // only do stuff if hit by a projectile
        if (newCollision.gameObject.tag == "Projectile") {

            Debug.Log("Target was hit by the projectile");
        
            if (explosionPrefab) {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate (explosionPrefab, transform.position, transform.rotation);
            }

            //countDownUIText.text = "0.00";
            gm.countDownUI.SetActive(false);
        
            // destroy the projectile
            Destroy (newCollision.gameObject);
				
            // destroy self
            Destroy (gameObject);
        }

        
    }
 
        
}
