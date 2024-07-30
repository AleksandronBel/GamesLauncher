using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject _finishWindow;
    [SerializeField] FinishTrigger _finishTrigger;
    
    void OnEnable()
    {
        _finishTrigger.OnFinishTriggered += SwitchFinishWindow;
    }

    void OnDisable()
    {
        _finishTrigger.OnFinishTriggered -= SwitchFinishWindow;
    }

    void SwitchFinishWindow()
    {
        _finishWindow.SetActive(true);
    }
}
