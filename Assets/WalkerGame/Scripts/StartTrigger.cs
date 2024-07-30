using System;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    public Action OnStartTriggered;

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            OnStartTriggered?.Invoke();
    }
}
