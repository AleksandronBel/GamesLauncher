using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public Action OnFinishTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
            OnFinishTriggered?.Invoke();
    }
}
