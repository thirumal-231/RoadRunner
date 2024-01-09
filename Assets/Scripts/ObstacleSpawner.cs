using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform spawnLocation1;
    [SerializeField] Transform spawnLocation2;
    [SerializeField] Transform spawnLocation3;
    Quaternion spawnRotation;

    private void OnEnable()
    {
        PlayerController.OnGameOver += StopSpawnOnGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= StopSpawnOnGameOver;
    }

    void Start()
    {
        spawnRotation = Quaternion.Euler(0, 180, 0);
        InvokeRepeating( "SpawnObstacles", 3f, 3f );
    }

    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        int randIndex = Random.Range(0, obstacles.Length);
        int randLocation = Random.Range(0,obstacles.Length);
        Transform location;

        switch(randLocation)
        {
            case 0: location = spawnLocation1; break;
            case 1: location = spawnLocation2; break;
            default: location = spawnLocation3; break;
        }

        Instantiate( obstacles[randIndex], location.position, spawnRotation );
    }

    void StopSpawnOnGameOver()
    {
        Destroy( gameObject.GetComponent<ObstacleSpawner>() );
    }
}
