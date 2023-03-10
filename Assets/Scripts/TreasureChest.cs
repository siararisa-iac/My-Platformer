using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable
{
    [SerializeField]
    private Sprite closed, open;
    private bool isClosed = true;

    private SpriteRenderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();   
    }

    public override void Interact()
    {
        Debug.Log("Interacting with the chest.");
        //toggle the boolean variable
        isClosed = !isClosed;
        //change the sprite
        myRenderer.sprite = isClosed ? closed : open;
    }
}
