using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationController : MonoBehaviour {
    private NavMeshAgent agent;
    private Animator animator;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        if (!AIHelperMethods.HasArrived(agent)) {
            animator.SetFloat("Speed", AIHelperMethods.GetCurrentAgentSpeed(agent));
        } else {
            animator.SetFloat("Speed", 0f);
        }
    }
}
