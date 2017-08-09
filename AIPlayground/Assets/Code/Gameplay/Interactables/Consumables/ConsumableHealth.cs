using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHealth : Consumable {
    void Start () {
	}
	
	void Update () {
    }

    protected override void Execute() {
        Debug.Log("Hi");
    }
}
