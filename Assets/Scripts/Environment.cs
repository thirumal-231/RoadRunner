using UnityEngine;

public class Environment : MonoBehaviour
{
    //public float worldSpeed = 30f;

    //private float speedIncrement = 0.01f;
    private Vector3 startPos;
    private float roadLength = 240f;

    private void OnEnable()
    {
        PlayerController.OnGameOver += StopWorldOnGameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnGameOver -= StopWorldOnGameOver;
    }

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        
        transform.Translate( Vector3.back * Time.deltaTime * ScoreManager.Instance.worldSpeed, Space.World);
        if(transform.position.z <= -roadLength)
        {
            transform.position = startPos;
        }

        //worldSpeed += speedIncrement;
    }

    void StopWorldOnGameOver()
    {
        Destroy(gameObject.GetComponent<Environment>());
    }
}
