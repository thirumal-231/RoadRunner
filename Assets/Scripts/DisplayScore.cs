using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOvercarText;
    public int currentScore = 0;

    private void OnEnable() {
        PlayerController.OnGameOver += UpdateHighScore;
    }

    private void OnDisable() {
        PlayerController.OnGameOver -= UpdateHighScore;
    }

    void UpdateHighScore()
    {
        gameOvercarText.text = $"Score : {currentScore} High : {ScoreManager.Instance.highScore}";
    }
}
