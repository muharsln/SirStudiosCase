using SirStudiosCase.Ball;
using SirStudiosCase.Score;
using UnityEngine;
using UnityEngine.UI;

namespace SirStudiosCase.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        #region Manager Objects
        [SerializeField] private GameManager _gameManager;
        #endregion

        #region Private Serialize Field
        [SerializeField] private GameObject[] _uiPanels;
        [SerializeField] private Button[] _panelButtons;
        #endregion

        #region Const Field
        private const byte GAME_START = 0, GAME_FINISH = 1;
        private const byte PLAY_BUTTON = 0, RESTART_BUTTON = 1;
        #endregion

        private void Awake() => Instance = this;

        private void Start() => GameUIPanelsSetActive();

        public void GameUIPanelsSetActive()
        {
            switch (_gameManager.state)
            {
                case GameManager.GameState.Start:
                    _uiPanels[GAME_START].SetActive(true);
                    break;
                case GameManager.GameState.Finish:
                    _uiPanels[GAME_FINISH].SetActive(true);
                    break;
                default:
                    _uiPanels[GAME_START].SetActive(false);
                    _uiPanels[GAME_FINISH].SetActive(false);
                    break;
            }
        }

        #region Buttons Clicked
        public void PlayButtonClicked()
        {
            // Oyun durumunu play yap ve ona göre panelleri düzenle
            _gameManager.state = GameManager.GameState.Play;
            GameUIPanelsSetActive();
        }

        public void RestartButtonClicked()
        {
            // Oyun durumunu play yap, top oluþtur, scoru sýfýrla ve panelleri düzenle
            _gameManager.state = GameManager.GameState.Play;
            BallSpawner.Instance.BallCreate();
            ScoreManager.Instance.ScoreReset();
            GameUIPanelsSetActive();
        }
        #endregion
    }
}