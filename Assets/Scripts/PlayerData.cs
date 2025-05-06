using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _score;

    public void AddScore(int amount) 
    {
        _score += amount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>();
        if (coin != null) 
        {
            AddScore(coin.Collect());
        }
    }
}
