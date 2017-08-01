using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class PlayerUtil {

    /** Normalized */
    public static float GetCurrentAgentSpeed(NavMeshAgent agent) {
        return Vector3.Magnitude(agent.velocity) / agent.speed;
    }
}
