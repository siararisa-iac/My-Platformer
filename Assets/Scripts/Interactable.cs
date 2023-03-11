using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public Transform instructions;
    public abstract void Interact();

    public void RepositionInstructions(Transform target) 
    {
        target.position = instructions.position;
    }
}
