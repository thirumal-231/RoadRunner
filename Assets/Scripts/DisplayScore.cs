using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverCoinText;
    [SerializeField] TextMeshProUGUI gameOvercarText;
    [SerializeField] TextMeshProUGUI gameOvertimeText;
    [SerializeField] GameOverScore gameOverScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();

        gameOverCoinText.text = $"Coins : {gameOverScore.coins} Best: {gameOverScore.bestCoins}";
        gameOvercarText.text = $"Cars : {gameOverScore.cars} Best: {gameOverScore.bestCars}";
        gameOvertimeText.text = $"Time : {gameOverScore.time} Best: {gameOverScore.bestTime}";
    }

    void UpdateHighScore()
    {
        // update coin highscore
        if(gameOverScore.coins >= gameOverScore.bestCoins )
        {
            gameOverScore.bestCoins = gameOverScore.coins;
        }
        
        // update cars highscore
        if(gameOverScore.cars >= gameOverScore.bestCars )
        {
            gameOverScore.bestCars = gameOverScore.cars;
        }
        
        // update cars time highscore
        if(gameOverScore.elapsedTime >= gameOverScore.bestElapsedTime )
        {
            gameOverScore.bestTime = gameOverScore.time;
        }
    }

    void changeElapsedTime()
    {
        gameOverScore.elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt( gameOverScore.elapsedTime / 60 );
        int seconds = Mathf.FloorToInt( gameOverScore.elapsedTime % 60 );
    }
}
