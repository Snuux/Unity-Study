using UnityEngine;
using UnityEngine.UI;

public class ViewUI : MonoBehaviour
{
    private const string TimerStringText = "Время: ";
    private const string CoinsStringText = "Монет собрано: ";

    [SerializeField] private GameState _gameState;

    [SerializeField] private CountdownTimer _timer;
    [SerializeField] private Text _timerText;

    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private Text _coinsPickedText;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;

    private void Update()
    {
        float currentTimer = _timer.CurrentTime;
        _timerText.text = TimerStringText + currentTimer.ToString("0.00");
        _coinsPickedText.text = CoinsStringText + _coinsManager.CountDisabled() + "/" + _coinsManager.Count;

        if (_gameState.IsWin())
            OnWin();
        else if (_gameState.IsLose())
            OnLose();
        else
            HideWinAndLosePanels();

    }

    public void OnWin()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnLose()
    {
        panelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideWinAndLosePanels()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);

        Time.timeScale = 1.0f;
    }
}
