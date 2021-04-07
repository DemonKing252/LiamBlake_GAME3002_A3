using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpringArm : MonoBehaviour
{
    [SerializeField]
    private float armLength = 0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0f, -1f, armLength);
    }

    // Update is called once per frame
    void Update()
    {
        // Need spring here
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - new Vector3(0f, -1f, armLength);
    }
}
