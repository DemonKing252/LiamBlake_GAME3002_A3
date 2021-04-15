using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            FindObjectOfType<GameManager>().activeKey = this.transform.parent.name;
            Destroy(gameObject);
        }
    }
}
