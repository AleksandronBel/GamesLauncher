using UnityEngine;

public class GetAssetsData : MonoBehaviour
{
    [SerializeField] Transform _positionToInstantiate;

    void Awake()
    {
        if (AssetManager.Instance.WalkerPrefab != null)
            Instantiate(AssetManager.Instance.WalkerPrefab, _positionToInstantiate.position, Quaternion.identity);
    }
}
