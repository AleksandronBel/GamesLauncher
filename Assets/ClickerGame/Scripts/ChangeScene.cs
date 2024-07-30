using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Action OnClickerExit;

    public void ChangeSceneToMenu()
    {
        SceneManager.LoadScene(0);
        OnClickerExit?.Invoke();
    }
}
