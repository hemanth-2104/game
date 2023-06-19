using UnityEngine;

public class ARRetryButton : MonoBehaviour
{
    public void OnRetryButtonClicked()
    {
        ARGameManager.instance.ResetGame();
    }
}
