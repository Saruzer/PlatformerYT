using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    public int Collect() 
    {
        Destroy(gameObject);
        return _value;
    }
}
