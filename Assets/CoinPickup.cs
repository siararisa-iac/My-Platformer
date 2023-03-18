using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayAudio("Coin");
            audioSource.Play();
            //Reward the player with score
            //Get the score componnt from the player
            ScoreManager.Instance.AddScore(1);
            Destroy(this.gameObject);
        }
    }
}
