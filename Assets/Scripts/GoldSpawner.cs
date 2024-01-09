using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [SerializeField] GameObject goldCoins;

    [SerializeField] Transform goldLocation1;
    [SerializeField] Transform goldLocation2;
    [SerializeField] Transform goldLocation3;

    private void OnEnable()
    {
        PlayerController.OnGameOver += StopGoldSpawnOnGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= StopGoldSpawnOnGameOver;
    }

    void Start()
    {
        InvokeRepeating( "SpawnGold", 0f, 3f );
    }

    void Update()
    {
        
    }

    void SpawnGold()
    {

        int randGoldLocation = Random.Range( 0, 3 );
        Transform location;

        switch( randGoldLocation )
        {
            case 0:
                location = goldLocation1;
                break;
            case 1:
                location = goldLocation2;
                break;
            default:
                location = goldLocation3;
                break;
        }
        Instantiate( goldCoins,location.position,Quaternion.identity);
    }

    void StopGoldSpawnOnGameOver()
    {
        Destroy( gameObject.GetComponent<GoldSpawner>() );
    }
}
