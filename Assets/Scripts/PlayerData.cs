using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHelath;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _healthBar;

    private void Start()
    {
        UpdateHealthBar();
        UpdateScoreText();
    }
    public void AddScore(int amount) 
    {
        _score += amount;
        UpdateScoreText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>();
        if (coin != null) 
        {
            AddScore(coin.Collect());
        }
    }
    private void UpdateScoreText() 
    {
        _scoreText.text = "Рахунок: " + _score.ToString();
    }
    private void UpdateHealthBar() 
    {
        _healthBar.fillAmount = (float)_health / (float)_maxHelath;
    }
}
