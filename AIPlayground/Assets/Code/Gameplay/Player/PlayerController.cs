using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : Controller {
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
    private PlayerSoundController psc;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        psc = GetComponent<PlayerSoundController>();
    }

    void Update() {
        if (pi.Reloading == false) {
            if (Input.GetButtonDown("Fire1")) {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    agent.SetDestination(hit.point);
                }
            }

            if (Input.GetButtonDown("Fire2") && pi.BulletsRemaining > 0) {
                SetFiring(true);
            } else if (Input.GetButtonUp("Fire2") || pi.NeedsReload()) {
                SetFiring(false);
            }
        }

        if (Input.GetButtonDown("Reload")) {
            if (CanReload()) {
                Reload();
            }
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

    private bool CanReload() {
        return AIHelperMethods.GetCurrentAgentSpeed(this, agent) == 0;
    }

    private void SetFiring(bool fire) {
        Debug.Log(fire);
        pi.Firing = fire;
    }

    private void Reload() {
        if (pi.Reloading == false) {
            pi.Reloading = true;
            psc.PlayReload();
        }
    }
}
