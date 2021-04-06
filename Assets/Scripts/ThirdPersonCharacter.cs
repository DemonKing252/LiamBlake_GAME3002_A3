using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpPower;


    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        // Is there a Surface underneath that we can jump on?

        bool collision = Physics.Linecast(transform.position + Vector3.up * 0.5f, transform.position - Vector3.up * 0.1f);
        
        if (collision && Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpPower, 0f);
            collision = false;
        }


        float horiz = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().velocity = new Vector3(horiz * speed, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        //GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);


        // Animations
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        vel.y = 0f;

        if (vel.magnitude != 0f)
        {
            GetComponent<Animator>().SetInteger("State", 1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("State", 0);
        } 
        if (horiz > 0f)
        {
            transform.localEulerAngles = new Vector3(0f, 90f, 0f);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0f, 270f, 0f);
        }

        var anim_speed = Mathf.Abs(vel.x) / speed;

        GetComponent<Animator>().SetFloat("Speed", anim_speed);
        GetComponent<Animator>().speed = anim_speed;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * 0.25f);
    }
}
