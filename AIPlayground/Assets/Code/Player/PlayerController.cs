using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    private NavMeshAgent agent;
    private PlayerInformation pi;
    public PlayerInformation PlayerInformation {
        get {
            if (pi == null) {
                pi = new PlayerInformation();
            }
            return pi;
        }
    }

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.point);
                agent.SetDestination(hit.point);
            }
        }
        if (Input.GetButtonDown("Fire2") && pi.BulletsRemaining > 0) {
            SetFiring(true);
        } else if(Input.GetButtonUp("Fire2") || pi.NeedsReload()) {
            SetFiring(false);
        }

        if(Input.GetButtonDown("Reload")) {
            Reload();
        }
    }

    private void OnDrawGizmos() {
        if (agent != null) {
            NavMeshPath path = agent.path;
            Vector3[] corners = path.corners;
            for (int i = 0; i < corners.Length - 1; i++) {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(corners[i], corners[i + 1]);
            }
        }
    }

    private void SetFiring(bool fire) {
        Debug.Log(fire);
        pi.Firing = fire;
    }

    private void Reload() {
        pi.BulletsRemaining = pi.ClipSize;
        Debug.Log("Reloaded: " + pi.BulletsRemaining);
    }
}
