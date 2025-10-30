using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] CountdownTimer _timer;
        [SerializeField] RigidbodyMovement _playerMovement;
        [SerializeField] PlayerController _playerController;

        [SerializeField] CoinsWallet _coinsWallet;
        [SerializeField] CoinsHolder _coinsHolder;

        public bool IsDebugWin { get; set; }
        public bool IsDebugLose { get; set; }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
                RestartGame();

            if (Input.GetKeyDown(KeyCode.V))
                IsDebugWin = true;

            if (Input.GetKeyDown(KeyCode.L))
                IsDebugLose = true;

            if (IsWin() || IsLose())
                PauseGame();
        }

        private void RestartGame()
        {
            _timer.ResetTimer();
            _timer.Continue();

            _coinsHolder.ResetCoinsCount();
            _coinsHolder.ResetCoins();
            _coinsWallet.ResetCoinsCount();

            _playerMovement.ResetPosition();
            _playerController.IsPaused = false;

            IsDebugWin = false;
            IsDebugLose = false;
        }

        public bool IsWin()
        {
            if (IsAllCoinsPicked() || IsDebugWin)
                return true;
            else
                return false;
        }

        public bool IsLose()
        {
            if (_timer.IsOver() || IsDebugLose)
                return true;
            else
                return false;
        }

        public bool IsAllCoinsPicked() => _coinsWallet.Count == _coinsHolder.Count;

        public void PauseGame()
        {
            _timer.Pause();
            _playerController.IsPaused = true;
            _playerMovement.Stop();
        }
    }
}