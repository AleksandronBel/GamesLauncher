using TMPro;
using UnityEngine;

public class CoinIncreaser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTextUI;

    public int Score { get; set; }

    void Start()
    {
        UpdateCoins();
    }

    public void IncreaseCoins()
    {
        Score++;
        UpdateCoins();
    }

    void UpdateCoins()
    {
        _scoreTextUI.text = Score.ToString();
    }
}

