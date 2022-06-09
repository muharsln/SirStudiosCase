using UnityEngine;
using UnityEngine.UI;

namespace SirStudiosCase.Score
{
    public class ScoreManager : MonoBehaviour
    {
        #region Public Field
        public static ScoreManager Instance { get; private set; }
        public int ScoreCount { get { return _scoreCount; } set { _scoreCount = value; } }
        #endregion

        #region Private Serialize Field
        [SerializeField] private Text _scoreText;
        [SerializeField] private int _scoreCount;
        #endregion

        #region Awake
        private void Awake() => Instance = this;
        #endregion

        #region Score Process
        public void ScoreUpdate()
        {
            ScoreCount += 10;
            _scoreText.text = _scoreCount.ToString();
        }

        public void ScoreReset()
        {
            _scoreCount = 0;
            _scoreText.text = _scoreCount.ToString();
        }
        #endregion
    }
}