using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private float _targetTime;
        private bool _isPaused;

        public float CurrentTime { get; private set; }

        private void Awake()
        {
            CurrentTime = _targetTime;
            _isPaused = false;
        }

        private void Update()
        {
            ProcessTimer();
        }

        private void ProcessTimer()
        {
            if (_isPaused == false)
            {
                if (CurrentTime > 0)
                    CurrentTime -= Time.deltaTime;
                else
                    CurrentTime = 0;
            }
        }

        public bool IsOver() => CurrentTime <= 0;

        public void ResetTimer() => CurrentTime = _targetTime;

        public void Pause() => _isPaused = true;

        public void Continue() => _isPaused = false;
    }
}