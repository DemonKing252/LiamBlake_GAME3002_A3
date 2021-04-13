using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private float dist;

    private bool m_collision = false;

    [SerializeField]
    private LayerMask groundMask;

    private bool sweepTest = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Check if theres an object in front of our current direction, don't allow the player
            // to walk into a wall to save them from falling 
            print("YESSSS");
            sweepTest = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // Check if theres an object in front of our current direction, don't allow the player
            // to walk into a wall to save them from falling 
            sweepTest = false;
        }
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        // I choose to use sphere casting over line casting because if the player center is partly off the edge of a ground, the cast will return NULL.
        // Sphere casting matches the player model the best

        RaycastHit info;
        Vector3 origin = transform.position + Vector3.up * (transform.localScale.y * 1.5f);

        m_collision = Physics.SphereCast(origin, transform.localScale.x * 0.3f, Vector3.down, out info, 1.51f);
        
        if (m_collision && Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpPower, 0f);
        }


        float horiz = Input.GetAxis("Horizontal");

        RaycastHit cast;
        Vector3 potentialVel = new Vector3(horiz * speed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);

        // Sweep test to prevent the player from charging into a wall and not falling, preventing him from falling (remove the !sweeptest and test to find out why this is important)
        if (!sweepTest)
        {
            //GetComponent<Rigidbody>().AddForce(potentialVel, ForceMode.Impulse);
            GetComponent<Rigidbody>().velocity = potentialVel;
        }

        // Animations
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        vel.y = 0f;

        if (m_collision)
        {
            GetComponent<Animator>().SetInteger("State", 1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 2);
        }
        if (horiz > 0f)
        {
            transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (horiz < 0f)
        {
            transform.localEulerAngles = new Vector3(0f, 270f, 0f);
        }

        var anim_speed = Mathf.Abs(vel.x) / speed;

        GetComponent<Animator>().SetFloat("Speed", anim_speed);
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 origin = transform.position + Vector3.up * (transform.localScale.y * 1.5f);
        Gizmos.DrawLine(origin, origin - Vector3.up * 1.51f);



    }
}
