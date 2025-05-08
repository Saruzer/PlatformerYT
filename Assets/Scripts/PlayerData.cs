using System.Collections;

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

    private float currentInvisTime = 0;
    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateHealthBar();
        UpdateScoreText();
    }
    private void Update()
    {
        if (currentInvisTime > 0)
        {
            currentInvisTime -= Time.deltaTime;
        }
        else if(sr.color.a < 1)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        Spike spike = collision.GetComponent<Spike>();
        if (spike != null && currentInvisTime <= 0)
        {
            TakeDamage(spike.GetDamage(), spike.GetInvisTime());
   
            UpdateHealthBar();
        }

    }
    private void TakeDamage(int amount, float invisTime) 
    {
        _health -= amount;
        if (_health < 0)
        {
            _health = 0;
        }
        currentInvisTime = invisTime;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.3f);
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
