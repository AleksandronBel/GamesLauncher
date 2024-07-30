using UnityEngine;

public class AssetManager : MonoBehaviour
{
    public static AssetManager Instance { get; private set; }
    public Sprite ClickerSprite { get; private set; }
    public GameObject WalkerPrefab { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetClickerSprite(Sprite sprite) => ClickerSprite = sprite;

    public void SetWalkerPrefab(GameObject prefab) => WalkerPrefab = prefab;
}
