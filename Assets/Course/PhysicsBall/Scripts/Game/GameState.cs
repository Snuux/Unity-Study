using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] CountdownTimer _timer;
    [SerializeField] CoinsManager _coinsManager;
    [SerializeField] RigidbodyMovement _playerMovement;

    public bool IsDebugWin { get; set; }
    public bool IsDebugLose { get; set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.V))
            IsDebugWin = true;

        if (Input.GetKeyDown(KeyCode.L))
            IsDebugLose = true;
    }

    private void RestartGame()
    {
        _timer.ResetTimer();
        _coinsManager.ResetCoins();
        _playerMovement.ResetPosition();

        IsDebugWin = false;
        IsDebugLose = false;
    }

    public bool IsWin()
    {
        if (_coinsManager.IsAllCoinsPicked() || IsDebugWin)
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
}
