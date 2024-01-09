using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI barriersText;
    [SerializeField] TextMeshProUGUI timeText;

    public GameOverScore runnerScore;

    private int barriersPassed = 0;
    private int coins = 0;
    float elapsedTime;

    private void OnEnable()
    {
        ObstacleDestroyer.OnObjectDestroy += UpdateBarriers;
        PlayerController.OnCoinTouch += UpdateCoins;
        PlayerController.OnGameOver += StopUpdateOnGameOver;
    }

    private void OnDisable()
    {
        ObstacleDestroyer.OnObjectDestroy -= UpdateBarriers;
        PlayerController.OnCoinTouch -= UpdateCoins;
        PlayerController.OnGameOver -= StopUpdateOnGameOver;
    }

    void Start()
    {
        barriersText.text = 0.ToString();
        coinsText.text = 0.ToString();
    }

    void Update()
    {
        UpdateTimer();
        WriteScoreIntoSO();
    }

    void UpdateBarriers()
    {
        barriersPassed++;
        barriersText.text = $"{barriersPassed}";
    }

    void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    void UpdateCoins()
    {
        coins += 5;
        coinsText.text = $"{coins}";
    }

    // unsubscribe when gameover
    void StopUpdateOnGameOver()
    {
        Destroy( gameObject.GetComponent<TextUpdater>() );
    }

    void WriteScoreIntoSO()
    {
        runnerScore.coins = coins;
        runnerScore.cars = barriersPassed;
        runnerScore.time = timeText.text;

        runnerScore.elapsedTime = elapsedTime;
    }
}
