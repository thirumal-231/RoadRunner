using DG.Tweening;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnCoinTouch;
    public static event Action OnGameOver;

    [SerializeField] Animator animator;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] AudioClips audioClips;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem runningParticles;

    private bool isOnGround;
    private bool isGameOver;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        StartRunning();
    }

    void Update()
    {
        SwitchParticles();
        HandleHorizontalMovement();
        JumpPlayer();
    }

    void StartRunning()
    {
        animator.SetBool("Static_b", true);
        animator.SetFloat("Speed_f", 0.51f);

    }

    void HandleHorizontalMovement()
    {
        if (isGameOver)
        {
            return;
        }



        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(audioClips.moveSound);

            if (transform.position.x > -3f && transform.position.x < 3f)
            {
                transform.DOMoveX(-3f, 0.25f);
            }
            if (transform.position.x > 0f && transform.position.x <= 3f)
            {
                transform.DOMoveX(0f, 0.25f);
            }
        }

        // Move Right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(audioClips.moveSound);

            if (transform.position.x > -3f && transform.position.x < 3f)
            {
                transform.DOMoveX(3f, 0.25f);
            }
            if (transform.position.x < 0f && transform.position.x >= -3f)
            {
                transform.DOMoveX(0f, 0.25f);
            }
        }
    }

    void JumpPlayer()
    {

        if (isGameOver)
        {
            return;
        }

        if (transform.position.y <= 0)
        {
            isOnGround = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            audioSource.PlayOneShot(audioClips.jumpSound);

            animator.SetBool("Jump_b", true);
            transform.DOMoveY(3, 0.5f);
            isOnGround = false;
        }
        if (transform.position.y >= 3)
        {
            animator.SetBool("Jump_b", false);
            transform.DOMoveY(0, 0.25f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGameOver)
        {
            return;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(audioClips.coinSound);

            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
            OnCoinTouch?.Invoke();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(audioClips.gameOverSound);

            gameOverCanvas.SetActive(true);
            animator.enabled = false;
            OnGameOver?.Invoke();
            isGameOver = true;
        }
    }

    // turn on off running particles
    private void SwitchParticles()
    {
        if (isOnGround)
        {
            var emission = runningParticles.emission; // Stores the module in a local variable
            emission.enabled = true;
        }
        else
        {
            var emission = runningParticles.emission; // Stores the module in a local variable
            emission.enabled = false;
        }
    }
}
