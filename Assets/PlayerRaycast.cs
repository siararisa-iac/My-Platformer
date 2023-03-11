using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float range = 2.0f;
    // We only want to hit objects in this layer
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform instructionsCanvas;

    private void Start()
    {
        instructionsCanvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        //Do a raycast
        //We will store the result of the raycast to the "hit" variable
        Vector2 direction = player.isFacingRight ? player.transform.right : -player.transform.right;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.position, direction, range, raycastMask);
        Debug.DrawRay(rayOrigin.position, direction, Color.red);
        //Check the result of "hit. Did we hit something?
        if (hit.collider != null && hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
        {
            instructionsCanvas.gameObject.SetActive(true);
            interactable.RepositionInstructions(instructionsCanvas);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
            //Do what you want with the hit result
            //Debug.Log($"Raycast hit {hit.collider.gameObject}");
            //Debug.Log(string.Format("Raycast hit [0] [1]", hit.collider.gameObject, transform.position));
            //Debug.Log("Raycast hit " + hit.collider.gameObject + " " + transform.position);
        }
        // Else, we didn't hit anything
        else
        {
            instructionsCanvas.gameObject.SetActive(false);
        }

    }
}
