using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMover : MonoBehaviour {

    public enum MotionDirections { Vertical, Horizontal };

    public MotionDirections motionType = MotionDirections.Vertical;
    
    private float magnitude = 0.2f;
    
    // Update is called once per frame
    void Update () {
        switch (motionType) {
            case MotionDirections.Vertical:
                transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * magnitude);
                break;
            case MotionDirections.Horizontal:
                transform.Translate(Vector3.back * Mathf.Sin(Time.timeSinceLevelLoad) * magnitude);
                break;
        }
        
    }
}
