using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperMover : MonoBehaviour {

    public enum MotionDirections { Right, Left };

    public MotionDirections motionType = MotionDirections.Right;
    public bool enableMotion = false;
    
    private float magnitude = 0.2f;
    
    // Update is called once per frame
    void Update () {
        if (enableMotion) {
            switch (motionType) {
                case MotionDirections.Right:
                    transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * magnitude);
                    break;
                case MotionDirections.Left:
                    transform.Translate(Vector3.left * Mathf.Sin(Time.timeSinceLevelLoad) * magnitude);
                    break;
            }
        }
    }
}
