using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 3f;

    //private void OnEnable()
    //{
    //    PlayerController.OnCoinTouch += CoinDestroy;
    //}

    //private void OnDisable()
    //{
    //    PlayerController.OnCoinTouch -= CoinDestroy;
    //}

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0,Space.World);
        transform.Translate( Vector3.back * Time.deltaTime * 30f, Space.World );

        if( transform.position.z <= -300f )
        {
            Destroy( gameObject );
        }
    }

    //void CoinDestroy()
    //{
    //    Destroy(this.gameObject);
    //}
}
