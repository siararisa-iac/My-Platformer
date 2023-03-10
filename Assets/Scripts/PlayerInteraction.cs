using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private List<Interactable> interactables = new List<Interactable>();

    private bool isInteracting = false;

    private void Update()
    {
        //We need to call the input check every frame
        //Only set the interact to true if the player presses the interact button
        isInteracting = Input.GetKeyDown(KeyCode.E);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Every time a trigger happens, we check if the object has an interactable component
        if(collision.TryGetComponent<Interactable>(out Interactable interactable))
        {
            //Check if the list already contains the interactable
            if (interactables.Contains(interactable)) return;
            //If it's not yet registered, add it to the list
            interactables.Add(interactable);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Interactable>(out Interactable interactable))
        {
            if (isInteracting)
            {
                //Check if the list has an element
                if (interactables.Count > 0)
                {
                    //Get the first element in the list, then interact with it
                    interactables[0].Interact();
                }
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Every time a trigger happens, we check if the object has an interactable component
        if (collision.TryGetComponent<Interactable>(out Interactable interactable))
        {
            //Check if the list contains the interactable
            if (interactables.Contains(interactable))
            {
                interactables.Remove(interactable);
            }
            
        }
    }
}
