using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {  
            // We need to get a reference of the PlayerScore component
            //Award the player score
            ScoreManager.Instance.AddScore(scoreValue);
            
            Debug.Log("Grant score to player");
            Destroy(this.gameObject);
        }
    }
}

