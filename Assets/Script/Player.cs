using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _damage = 10;
    private float _treatment = 10;
    private EventFloat _healthChanged = new EventFloat();

    public float Health { get; private set; }

    private void Start()
    {
        Health = _maxHealth;
    }
    public void TakeDamage()
    {
        if(Health>=_damage)
        Health -= _damage;
        _healthChanged.Invoke(Health);
    }

    public void UseTreatment()
    {
        if(Health<_maxHealth)
        Health += _treatment;
        _healthChanged.Invoke(Health);
    }

    public void AddListener(UnityAction<float> action)
    {
        _healthChanged.AddListener(action);
    }

    public void RemoveListener(UnityAction<float> action)
    {
        _healthChanged.RemoveListener(action);
    }
}

[System.Serializable]

public class EventFloat : UnityEvent<float> { }
