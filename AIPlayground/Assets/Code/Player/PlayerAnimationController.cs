using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update() {
        if (!hasArrived()) {
            animator.SetFloat("Speed", getCurrentAgentSpeed());
        } else {
            animator.SetFloat("Speed", 0f);
        }
    }

    private bool hasArrived() {
        if (!agent.pathPending) {
            if (agent.remainingDistance <= agent.stoppingDistance) {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                    return true;
                }
            }
        }
        return false;
    }

    /** Normalized */
    private float getCurrentAgentSpeed() {
        return Vector3.Magnitude(agent.velocity) / agent.speed;
    }
}
