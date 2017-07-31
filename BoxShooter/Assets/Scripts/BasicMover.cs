using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour {

    public float spinSpeed = 180.0f;
    public float motionMagnitued = 0.1f;

    public bool doSpin = true;
    public bool doMotion = false;

    // Update is called once per frame
    void Update () {
        
        if (doSpin) { 
            // Rotate around the up axis of the gameObject
            Vector3 angle = Vector3.up * spinSpeed * Time.deltaTime;
            gameObject.transform.Rotate(angle);
        }

        if (doMotion) {
            // move up and down over time
            Vector3 scale = Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitued;
            gameObject.transform.Translate(scale);
        }
    }
}
