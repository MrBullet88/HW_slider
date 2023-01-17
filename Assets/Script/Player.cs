using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static UnityAction<float> HealthCanged;

    private float _maxHealth = 100;
    private float _damage = 10;
    private float _treatment = 10;
    
    public float Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
    }
    public void TakeDamage()
    {
        if(Health>=_damage)
        Health -= _damage;
        HealthCanged?.Invoke(Health);
    }

    public void UseTreatment()
    {
        if(Health<_maxHealth)
        Health += _treatment;
        HealthCanged?.Invoke(Health);
    }
}

