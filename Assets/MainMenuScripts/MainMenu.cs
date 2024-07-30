using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _playClickerButton;
    [SerializeField] Button _loadClickerButton;
    [SerializeField] Button _unloadClickerButton;

    [SerializeField] Button _playWalkerButton;
    [SerializeField] Button _loadWalkerButton;
    [SerializeField] Button _unloadWalkerButton;

    [SerializeField] AddressablesLoader _addressablesLoader;

    void OnEnable()
    {
        _addressablesLoader.OnLoadedClicker += UpdateClickerStatus;
        _addressablesLoader.OnUnloadedClicker += UpdateClickerStatus;
        _addressablesLoader.OnLoadedWalker += UpdateWalkerStatus;
        _addressablesLoader.OnUnloadedWalker += UpdateWalkerStatus;
    }

    void OnDisable()
    {
        _addressablesLoader.OnLoadedClicker -= UpdateClickerStatus;
        _addressablesLoader.OnUnloadedClicker -= UpdateClickerStatus;
        _addressablesLoader.OnLoadedWalker -= UpdateWalkerStatus;
        _addressablesLoader.OnUnloadedWalker -= UpdateWalkerStatus;
    }

    void Start()
    {
        AssignButtonEvents();
        UpdateClickerStatus();
        UpdateWalkerStatus();
    }

    void AssignButtonEvents()
    {
        _playClickerButton.onClick.AddListener(() => LoadScene(1));
        _loadClickerButton.onClick.AddListener(_addressablesLoader.LoadAssetsForClicker);
        _unloadClickerButton.onClick.AddListener(_addressablesLoader.UnloadAssetsForClicker);

        _playWalkerButton.onClick.AddListener(() => LoadScene(2));
        _loadWalkerButton.onClick.AddListener(_addressablesLoader.LoadAssetsForWalker);
        _unloadWalkerButton.onClick.AddListener(_addressablesLoader.UnloadAssetsForWalker);
    }

    void UpdateClickerStatus() => _playClickerButton.interactable = AssetManager.Instance.ClickerSprite != null;

    void UpdateWalkerStatus() => _playWalkerButton.interactable = AssetManager.Instance.WalkerPrefab != null;

    void LoadScene(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
