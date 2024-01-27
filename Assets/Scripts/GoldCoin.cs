using UnityEngine;

public class GoldCoin : MonoBehaviour
{

    public static GoldCoin Instance;

    
    private float rotationSpeed = 3f;

    //private float speed = 30f;
    //private float speedIncrement = 0.01f;

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
        transform.Rotate(0, rotationSpeed, 0, Space.World);
        transform.Translate(Vector3.back * Time.deltaTime * ScoreManager.Instance.worldSpeed, Space.World);

        //speed += speedIncrement;

        if (transform.position.z <= -300f)
        {
            Destroy(gameObject);
        }
    }

    //void CoinDestroy()
    //{
    //    Destroy(this.gameObject);
    //}
}
