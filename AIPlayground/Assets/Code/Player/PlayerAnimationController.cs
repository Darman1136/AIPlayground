using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerInformation pi;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pi = GetComponent<PlayerController>().PlayerInformation;
    }
    void Update() {
        if (!HasArrived()) {
            animator.SetFloat("Speed", GetCurrentAgentSpeed());
        } else {
            animator.SetFloat("Speed", 0f);
        }

        animator.SetBool("Firing", pi.Firing);
    }

    private bool HasArrived() {
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
    private float GetCurrentAgentSpeed() {
        return Vector3.Magnitude(agent.velocity) / agent.speed;
    }

    public void FireAnimationEvent() {
        if (pi.Firing) {
            pi.BulletsRemaining--;
            Debug.Log(pi.BulletsRemaining);
        }
    }
}
