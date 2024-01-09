using UnityEngine;

[CreateAssetMenu(fileName = "Runner_Score")]
public class GameOverScore : ScriptableObject
{
    public int coins = 0;
    public int cars = 0;
    public string time = string.Empty;

    public float elapsedTime = 0;

    public int bestCoins = 0;
    public int bestCars = 0;
    public string bestTime = string.Empty;
    public float bestElapsedTime = 0;


}
