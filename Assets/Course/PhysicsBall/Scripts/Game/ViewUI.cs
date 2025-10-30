using UnityEngine;
using UnityEngine.UI;
namespace Assets.Course.PhysicsBall
{
    public class ViewUI : MonoBehaviour
    {
        private const string TimerStringText = "Время: ";
        private const string CoinsStringText = "Монет собрано: ";

        [SerializeField] private GameState _gameState;

        [SerializeField] private CountdownTimer _timer;
        [SerializeField] private Text _timerText;

        [SerializeField] private CoinsHolder _coinsHolder;
        [SerializeField] private CoinsWallet _coinsWallet;
        [SerializeField] private Text _coinsPickedText;

        [SerializeField] private GameObject panelWin;
        [SerializeField] private GameObject panelLose;

        private void Update()
        {
            _timerText.text = TimerStringText + _timer.CurrentTime.ToString("0.00");
            _coinsPickedText.text = CoinsStringText + _coinsWallet.Count + "/" + _coinsHolder.Count;

            if (_gameState.IsWin())
                OnWin();
            else if (_gameState.IsLose())
                OnLose();
            else
                HideWinAndLosePanels();
        }

        private void OnWin()
        {
            panelWin.SetActive(true);
        }

        private void OnLose()
        {
            panelLose.SetActive(true);
        }

        private void HideWinAndLosePanels()
        {
            panelWin.SetActive(false);
            panelLose.SetActive(false);
        }
    }
}