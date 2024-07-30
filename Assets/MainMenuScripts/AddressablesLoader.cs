using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesLoader : MonoBehaviour
{
    [SerializeField] AssetReference _clicker;
    [SerializeField] AssetReference _walker;

    public Action OnLoadedClicker;
    public Action OnLoadedWalker;

    public Action OnUnloadedClicker;
    public Action OnUnloadedWalker;

    public async void LoadAssetsForClicker()
    {
        AsyncOperationHandle<Sprite> handle = _clicker.LoadAssetAsync<Sprite>();
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;
            AssetManager.Instance.SetClickerSprite(sprite);

            OnLoadedClicker?.Invoke();
        }
    }

    public async void LoadAssetsForWalker()
    {
        AsyncOperationHandle<GameObject> handle = _walker.LoadAssetAsync<GameObject>();
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObjectPrefab = handle.Result;
            AssetManager.Instance.SetWalkerPrefab(gameObjectPrefab);

            OnLoadedWalker?.Invoke();
        }
    }

    public void UnloadAssetsForClicker()
    {
        if (AssetManager.Instance.ClickerSprite != null)
        {
            Addressables.Release(AssetManager.Instance.ClickerSprite);
            AssetManager.Instance.SetClickerSprite(null);

            OnUnloadedClicker?.Invoke();
        }
    }

    public void UnloadAssetsForWalker()
    {
        if (AssetManager.Instance.WalkerPrefab != null)
        {
            Addressables.Release(AssetManager.Instance.WalkerPrefab);
            AssetManager.Instance.SetWalkerPrefab(null);

            OnUnloadedWalker?.Invoke();
        }
    }
}