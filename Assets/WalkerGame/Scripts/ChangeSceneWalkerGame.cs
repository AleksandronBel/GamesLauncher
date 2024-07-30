using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWalkerGame : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeSceneToMenu()
    {
        SceneManager.LoadScene(0);
        //OnClickerExit?.Invoke();
    }
}
