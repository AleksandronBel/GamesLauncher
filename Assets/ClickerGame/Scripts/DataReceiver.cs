using UnityEngine;
using UnityEngine.UI;

public class DataReceiver : MonoBehaviour
{
    [SerializeField] Button _button;

    void Awake()
    {
        if (AssetManager.Instance.ClickerSprite != null)
            _button.image.sprite = AssetManager.Instance.ClickerSprite;
    }
}
