using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxAttempts = 3;

    private int score;
    private int attempts;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        score = 0;
        attempts = 0;
        uiManager.UpdateScore(score);
        uiManager.EnableRetryButton(false);
    }

    private void IncrementScore(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    public void AttemptFailed()
    {
        attempts++;
        if (attempts >= maxAttempts)
        {
            uiManager.EnableRetryButton(true);
        }
    }

    public void RetryGame()
    {
        ResetGame();
    }
}
