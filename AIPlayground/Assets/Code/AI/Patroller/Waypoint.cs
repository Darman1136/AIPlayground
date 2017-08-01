using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public AnimationClip animationOnReached;
    public AnimationClip AnimationOnReached {
        get {
            return animationOnReached;
        }
        set {
            animationOnReached = value;
        }
           
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}
