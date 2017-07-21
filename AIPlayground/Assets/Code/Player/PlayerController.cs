using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    private NavMeshAgent agent;

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
}
