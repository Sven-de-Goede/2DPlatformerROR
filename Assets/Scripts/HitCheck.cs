using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
void OnCTriggerEnter2D(Collision collision) {
    Collider myCollider = collision.GetContact(0).thisCollider;
    Debug.Log(myCollider);
    // Now do whatever you need with myCollider.
    // (If multiple colliders were involved in the collision, 
    // you can find them all by iterating through the contacts)
}
}
