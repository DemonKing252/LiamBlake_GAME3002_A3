using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private float jumpBoost;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            // Jump boost (reflecting players velocity * an impulse)
            Vector3 incomingVel = collider.GetComponent<Rigidbody>().velocity;
            incomingVel = Vector3.Reflect(incomingVel.normalized, Vector3.up);
            incomingVel *= jumpBoost;

            collider.GetComponent<Rigidbody>().velocity = incomingVel;
        }
    }
}
