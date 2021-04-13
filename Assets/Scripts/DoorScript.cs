using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool playerColliding = false;

    private JointSpring jspring;

    [SerializeField]
    private float openedPosition;
    
    [SerializeField]
    private float closedPosition;

    private void Start()
    {
        jspring = GetComponent<HingeJoint>().spring;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Only if the key is aquired, open door
            if (FindObjectOfType<GameManager>().KeyAquired)
                playerColliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerColliding = false;
        }
    }
    private void FixedUpdate()
    {
        if (playerColliding)
            print("Press E to open door");

        // player colliding doesn't get set if the key isn't aquired
        if (Input.GetKey(KeyCode.E) && playerColliding)
        {
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        // 5 seconds to go through door after pressing 'E'

        jspring.targetPosition = openedPosition;
        GetComponent<HingeJoint>().spring = jspring;

        Invoke("CloseDoor", 5.0f);
    }
    private void CloseDoor()
    {
        jspring.targetPosition = closedPosition;
        GetComponent<HingeJoint>().spring = jspring;
    }
}
