using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;
    private AIController aiController;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        aiController = GetComponent<AIController>();
    }

    void Update() {
        if (!AIHelperMethods.HasArrived(agent)) {
            animator.SetFloat("Speed", AIHelperMethods.GetCurrentAgentSpeed(aiController, agent));
        } else {
            animator.SetFloat("Speed", 0f);
        }
    }
}
