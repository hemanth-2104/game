using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button retryButton;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void EnableRetryButton(bool enable)
    {
        retryButton.interactable = enable;
    }
}
