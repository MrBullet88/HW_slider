using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;

    
    private float _speed = 4f;
    private float _playerHealth;

    private void Start()
    {
        _playerHealth = _player.Health;
    }

    private void Update()
    {
        if (_healthSlider.value != _playerHealth)
        { 
           float currentHealth = Mathf.MoveTowards(_healthSlider.value, _playerHealth, Time.deltaTime*_speed);
          _healthSlider.value = currentHealth;          
        }                   
    }
    public void SetHealth(float health)
    {
        _playerHealth = health;         
    }

    private void OnEnable()
    {
        _player.AddListener(SetHealth);
    }

    private void OnDisable()
    {
        _player.RemoveListener(SetHealth);
    }
}
