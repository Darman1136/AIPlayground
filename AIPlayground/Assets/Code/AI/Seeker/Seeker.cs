using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : AIController {

	void Start () {
        base.OnStart();
	}
	
	void Update () {
        base.OnUpdate();
        ScanForEnemy();

        if(target) {
            RotateTo(target);
        }
    }

    private void ScanForEnemy() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        bool foundPlayer = false;
        foreach (var p in players) {
            if(IsInFov(p)) {
                target = p;
                foundPlayer = true;
            }
        }

        if(!foundPlayer) {
            target = null;
        }
    }
}
