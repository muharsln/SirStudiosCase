using SirStudiosCase.Ball;
using SirStudiosCase.Score;
using UnityEngine;
using UnityEngine.UI;

namespace SirStudiosCase.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        #region Private Serialize Field
        [SerializeField] private GameObject[] _uiPanels;
        #endregion

        #region Const Field
        private const byte GameStart = 0, GameFinish = 1;
        #endregion

        private void Awake() => Instance = this;

        private void Start() => GameUIPanelsSetActive();

        public void GameUIPanelsSetActive()
        {
            switch (GameManager.Instance.ReturnGameState())
            {
                case GameManager.GameState.Start:
                    _uiPanels[GameStart].SetActive(true);
                    break;
                case GameManager.GameState.Finish:
                    _uiPanels[GameFinish].SetActive(true);
                    break;
                default:
                    _uiPanels[GameStart].SetActive(false);
                    _uiPanels[GameFinish].SetActive(false);
                    break;
            }
        }

        #region Buttons Clicked
        public void PlayButtonClicked()
        {
            // Oyun durumunu play yap ve ona göre panelleri düzenle
            GameManager.Instance.SetGameState(GameManager.GameState.Play);
            GameUIPanelsSetActive();
        }

        public void RestartButtonClicked()
        {
            // Oyun durumunu play yap, top oluþtur, scoru sýfýrla ve panelleri düzenle
            GameManager.Instance.SetGameState(GameManager.GameState.Play);
            BallSpawner.Instance.BallCreate();
            ScoreManager.Instance.ScoreReset();
            GameUIPanelsSetActive();
        }
        #endregion
    }
}