using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    // constant
    public Vector3 desiredTorque;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GetComponent<Rigidbody>().AddTorque(desiredTorque * Time.deltaTime, ForceMode.Impulse);
    }
}
