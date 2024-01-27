using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //[SerializeField] float speed = 30f;

    //private float speedIncrement = 0.01f;

    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate( Vector3.back * ScoreManager.Instance.worldSpeed * Time.deltaTime, Space.World );
        //speed += speedIncrement;
        
    }

}
