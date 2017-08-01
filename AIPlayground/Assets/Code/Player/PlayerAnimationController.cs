using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerInformation pi;
    private PlayerSoundController psc;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pi = GetComponent<PlayerController>().PlayerInformation;
        psc = GetComponent<PlayerSoundController>();
    }

    void Update() {
        if (!HasArrived()) {
            animator.SetFloat("Speed", PlayerUtil.GetCurrentAgentSpeed(agent));
        } else {
            animator.SetFloat("Speed", 0f);
        }

        animator.SetBool("Firing", pi.Firing);
        animator.SetBool("Reloading", pi.Reloading);
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

    public void FireAnimationEvent() {
        if (pi.Firing) {
            pi.ShotFired();
            psc.PlayShotFired();
            Debug.Log(pi.BulletsRemaining);
        }
    }

    public void ReloadDoneAnimationEvent() {
        pi.Reload();
        pi.Reloading = false;
    }
}
