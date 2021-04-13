using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().KeyAquired = true;
        Destroy(gameObject);
    }
}
