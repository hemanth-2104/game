using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ARGameManager : MonoBehaviour
{
    public static ARGameManager instance; // Singleton instance

    public int score = 0;
    public int maxAttempts = 3;
    public int currentAttempt = 0;

    [SerializeField] public Text scoreText;
    [SerializeField] public Text attemptsText;
    public GameObject retryButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetGame();
    }

    public void IncrementScore()
    {
        score += 5;
        UpdateUI();

        if (score >= 15)
        {
            // Game over logic
        }
    }

    public void ResetGame()
    {
        score = 0;
        currentAttempt = 0;
        retryButton.SetActive(false);
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        attemptsText.text = "Attempts: " + (maxAttempts - currentAttempt);
    }
}
