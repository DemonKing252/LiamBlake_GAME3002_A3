using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    // Torque object #1:
    // Spike hazard that rotates on 0, 1, 0 whenever the player is near. Spike can kill you if it has torque applied to be careful!

    [SerializeField]
    private float detectionRadius;

    [SerializeField]
    private float forceApplied;

    [SerializeField]
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= detectionRadius)
        {
            transform.Find("Mesh").GetComponent<Rigidbody>().AddTorque(Vector3.up * forceApplied * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
