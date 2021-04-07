using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpringArm : MonoBehaviour
{
    [SerializeField]
    private float armHeight = 1f;   // height from centre of player

    [SerializeField]
    private float armLength = 0f;

    [SerializeField]
    private float dampingCoeff = 1f;

    [SerializeField]
    private float springConstant = -200f;

    // Damping
    private Vector3 previousVel;

    // Start is called before the first frame update
    void Start()
    {
        // Spring arm starts at rest position:
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0f, -armHeight, armLength);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 origin = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0f, -armHeight, armLength);
        Vector3 direction = origin - transform.position;

        float mag = Vector3.Distance(transform.position, origin);

        // Spring force = -coeff of friction x distance from origin of spring
        // Fs = -k * x
        Vector3 normalForce = -springConstant * direction - dampingCoeff * (GetComponent<Rigidbody>().velocity - previousVel);
        GetComponent<Rigidbody>().AddForce(normalForce, ForceMode.Acceleration);
        previousVel = GetComponent<Rigidbody>().velocity;


        // Need spring here
    }
}
