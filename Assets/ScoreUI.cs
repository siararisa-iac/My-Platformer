using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    //Update the score text here
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
