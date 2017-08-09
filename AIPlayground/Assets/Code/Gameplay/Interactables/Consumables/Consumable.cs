using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Interactable {
    protected override void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag(TagHelperMethods.TAG_PLAYER)) {
            Execute();
        }
    }
}