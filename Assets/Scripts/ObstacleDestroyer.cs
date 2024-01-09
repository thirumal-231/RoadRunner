using System;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public static event Action OnObjectDestroy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter( Collider other )
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            OnObjectDestroy?.Invoke();
        }
        // subscribe score function with this
        Destroy( other.gameObject );
    }
}
