using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour {

    protected abstract void OnTriggerEnter(Collider collision);

    protected abstract void Execute();

    protected void DestoryThis() {
        Destroy(this.gameObject);
    }
}
