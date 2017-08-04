using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHelperMethods {
    /** Normalized */
    public static float GetCurrentAgentSpeed(Controller controller, NavMeshAgent agent) {
        return Vector3.Magnitude(agent.velocity) / controller.runSpeed;
    }

    public static  bool HasArrived(NavMeshAgent agent) {
        if (!agent.pathPending) {
            if (agent.remainingDistance <= agent.stoppingDistance) {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                    return true;
                }
            }
        }
        return false;
    }
}
