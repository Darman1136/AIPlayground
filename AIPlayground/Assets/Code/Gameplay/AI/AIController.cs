﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIController : Controller {
    public Transform headTransform;

    [Range(1, 359)]
    public float fov = 90f;
    [Range(1, 100)]
    public float viewDistance = 30f;
    [Range(0f, 20f)]
    public float turnSpeed = 10f;

    protected GameObject target;

    protected NavMeshAgent agent;

    protected bool active = true;

    protected void OnStart() {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void OnUpdate() {
        if(active) {
            //
        }
    }

    private void OnDrawGizmos() {
        float halfFov = fov / 2f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFov, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFov, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * getFixedHeadForwardTransform();
        Vector3 rightRayDirection = rightRayRotation * getFixedHeadForwardTransform();

        if (target) {
            Gizmos.color = Color.red;
        } else {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(headTransform.position, leftRayDirection * viewDistance);
        Gizmos.DrawRay(headTransform.position, rightRayDirection * viewDistance);
    }

    protected bool IsInFov(GameObject go) {
        Vector3 direction = (go.transform.position - headTransform.position).normalized;
        float dot = Vector3.Dot(direction, getFixedHeadForwardTransform());
        float distance  = Vector3.Distance(go.transform.position, headTransform.position);
        return  (1 - ((fov / 2f) / 100)) < dot && distance < viewDistance;
    }

    private Vector3 getFixedHeadForwardTransform() {
        return Quaternion.Euler(0, 90, 0) * headTransform.forward;
    }

    protected void RotateTo(GameObject go) {
        RotateTo(go.transform);
    }

    protected void RotateTo(Transform t) {
        Vector3 direction = (t.position - transform.position).normalized;
        Quaternion newRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * turnSpeed);
    }

    protected bool HasArrived() {
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
