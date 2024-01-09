using System;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate( Vector3.back * speed * Time.deltaTime, Space.World );
        
    }

}
