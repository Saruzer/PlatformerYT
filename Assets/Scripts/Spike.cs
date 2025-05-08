using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _invisTimeAfterHit;

    public int GetDamage() 
    {
        return _damage;
    }
    public float GetInvisTime() 
    {
        return _invisTimeAfterHit;
    }
}
