using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore(1);
            audioManager.CoinSound();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Trap"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            gameManager.GameWin();
            Destroy(collision.gameObject);
        }
    }
}
