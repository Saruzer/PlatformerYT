using TMPro;

using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
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
}
