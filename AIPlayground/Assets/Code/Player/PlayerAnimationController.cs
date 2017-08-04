using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerController pc;
    private PlayerInformation pi;
    private PlayerSoundController psc;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        pi = GetComponent<PlayerController>().PlayerInformation;
        psc = GetComponent<PlayerSoundController>();
        pc = GetComponent<PlayerController>();
    }

    void Update() {
        if (!AIHelperMethods.HasArrived(agent)) {
            animator.SetFloat("Speed", AIHelperMethods.GetCurrentAgentSpeed(pc, agent));
        } else {
            animator.SetFloat("Speed", 0f);
        }

        animator.SetBool("Firing", pi.Firing);
        animator.SetBool("Reloading", pi.Reloading);
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
