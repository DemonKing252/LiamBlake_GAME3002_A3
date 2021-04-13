using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Works, because you can't go to the next room until you get the previous key
    [SerializeField]
    public bool KeyAquired;

}
