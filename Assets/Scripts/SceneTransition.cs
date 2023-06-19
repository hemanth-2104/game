using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    // This method will be called when the button is clicked
    public void LoadScene()
    {
        // Load the scene with the specified name
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}