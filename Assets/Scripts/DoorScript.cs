using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    GameObject keyNeeded;


    [SerializeField]
    private string keyNeeded_Str;

    private JointSpring jspring;

    [SerializeField]
    private float openedPosition;
    
    [SerializeField]
    private float closedPosition;

    private bool playerColliding = false;

    private void Start()
    {
        if (keyNeeded != null)
            keyNeeded_Str = keyNeeded.name;

        jspring = GetComponent<HingeJoint>().spring;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Can't open the door from the left side!
        if (other.gameObject.transform.position.x < this.transform.position.x)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Only if the key is aquired, open door
                if (FindObjectOfType<GameManager>().activeKey == keyNeeded_Str)
                {
                    playerColliding = true;
                }
                else if (FindObjectOfType<GameManager>().activeKey == "")
                {
                    FindObjectOfType<GameManager>().AddMessage("Missing Key!", 5f);
                }
                else if (FindObjectOfType<GameManager>().activeKey != keyNeeded_Str)
                {
                    FindObjectOfType<GameManager>().AddMessage("Wrong Key!", 5f);
                }
            }
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerColliding = false;
        }
    }
    private void Update()
    {
        if (playerColliding)
        {

            FindObjectOfType<GameManager>().AddMessage("Press [E] to open door", Time.deltaTime);
        }
        
        // player colliding doesn't get set if the key isn't aquired
        if (Input.GetKey(KeyCode.E) && playerColliding)
        {
            FindObjectOfType<GameManager>().AddMessage("Door Opened!", 5f);
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
