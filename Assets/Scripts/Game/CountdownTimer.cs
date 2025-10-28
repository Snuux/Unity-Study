using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float _countdownSeconds;
    private float _currentTime = 0;

    public float CurrentTime => _currentTime;

    private void Awake()
    {
        _currentTime = _countdownSeconds;
    }

    private void Update()
    {
        ProcessTimer();
    }

    private void ProcessTimer()
    {
        if (_currentTime > 0)
            _currentTime -= Time.deltaTime;
        else
            _currentTime = 0;
    }

    public bool IsOver() => _currentTime <= 0;

    public void ResetTimer() => _currentTime = _countdownSeconds;
}
