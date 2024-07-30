using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    [SerializeField] CoinIncreaser _coinIncreaser;
    [SerializeField] ChangeScene _changeScene;

    void Awake()
    {
        _coinIncreaser.Score = PlayerPrefs.GetInt("Points");
    }

    void OnEnable()
    {
        _changeScene.OnClickerExit += SaveCoins;
    }

    void OnDisable()
    {
        _changeScene.OnClickerExit -= SaveCoins;
    }

    void SaveCoins()
    {
        PlayerPrefs.SetInt("Points", _coinIncreaser.Score);
    }
}
