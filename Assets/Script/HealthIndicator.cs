using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
      
    private float _speed = 7f;
    private float _playerHealth;
    private Coroutine _healthCangeJob;

    private void Start()
    {
        _playerHealth = FindObjectOfType<Player>().Health;
    }

    private void OnEnable()
    {
        Player.HealthCanged += OnHealthCanged;
    }

    private void OnDisable()
    {
        Player.HealthCanged -= OnHealthCanged;
    }

    public void StartHealthCoroutine()
    {
        if (_healthCangeJob != null)
            StopCoroutine(_healthCangeJob);

        _healthCangeJob = StartCoroutine(ChangeHealth());
    } 
    
    public void OnHealthCanged(float health)
    {
        _playerHealth = health;
        StartHealthCoroutine();
    }

    private IEnumerator ChangeHealth()
    {
        while(_healthSlider.value != _playerHealth)
        {
            float currentHealth = Mathf.MoveTowards(_healthSlider.value, _playerHealth, Time.deltaTime*_speed);
            _healthSlider.value = currentHealth;  
            yield return null;
        }    
    }
}
