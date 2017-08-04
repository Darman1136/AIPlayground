using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float runSpeed = 3.5f;
    public float walkSpeed = 1f;
    public float crouchSpeed = .5f;

    public float getRunSpeed() {
        return runSpeed;
    }
    public float getWalkSpeed() {
        return runSpeed;
    }
    public float getCrouchSpeed() {
        return runSpeed;
    }
}
