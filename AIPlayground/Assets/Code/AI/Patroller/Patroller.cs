using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : AIController {
    public enum WaypointOrdering { FIFO, Random }

    public WaypointOrdering waypointOrder;
    public Waypoint[] waypoints;

    private Waypoint nextWaypoint;
    private int currentWaypointIndex = -1;

    void Start() {
        base.OnStart();
        if (waypoints.Length == 0) {
            active = false;
        } else {
            nextWaypoint = getNextWaypoint();
            agent.SetDestination(nextWaypoint.transform.position);
        }
    }

    void Update() {
        base.OnUpdate();
        if (active) {
            if (HasArrived()) {
                nextWaypoint = getNextWaypoint();
                agent.SetDestination(nextWaypoint.transform.position);
            }
        }
    }

    private Waypoint getNextWaypoint() {
        Waypoint ret = null;
        switch (waypointOrder) {
            case WaypointOrdering.FIFO:
                ret = waypoints[++currentWaypointIndex % waypoints.Length];
                break;
            case WaypointOrdering.Random:
                ret = waypoints[Random.Range(0, waypoints.Length)];
                break;
        }
        return ret;
    }
}
