using SirStudiosCase.Score;
using SirStudiosCase.UI;
using UnityEngine;

namespace SirStudiosCase.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Private Serialize Field
        [SerializeField] private DynamicJoystick _joystick;
        [SerializeField] private float _moveSpeed, _rotateSpeed;
        #endregion

        #region Private Field
        private float _horizontal, _vertical;
        private Vector3 _startPosition, _playerDirection;
        private Quaternion _startRotation;
        #endregion

        #region Awake
        private void Awake()
        {
            // Initial pos and rot update when the game starts
            _startPosition = transform.position;
            _startRotation = transform.rotation;
        }
        #endregion

        #region FixedUpdate
        private void Update()
        {
            // If GameState is Play and TouchCount is greater than 0
            if (GameManager.Instance.state == GameManager.GameState.Play && Input.touchCount > 0)
            {
                _horizontal = _joystick.Horizontal;
                _vertical = _joystick.Vertical;
                PlayerMovement();
            }
        }
        #endregion

        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.GetComponent<ICollectable>();
            // If the collactable object is not empty
            if (collectable != null)
            {
                other.GetComponent<ICollectable>().Collect();
                // Score text updated
                ScoreManager.Instance.ScoreUpdate();

                if (ScoreManager.Instance.ScoreCount == 100)
                {
                    // GameState updated
                    GameManager.Instance.SetGameState(GameManager.GameState.Finish);
                    // UI panel changing
                    UIManager.Instance.GameUIPanelsSetActive();
                    // Position and rotation values is reset
                    transform.position = _startPosition;
                    transform.rotation = _startRotation;
                }
            }
        }
        #endregion

        #region Player Movement
        private void PlayerMovement()
        {
            PlayerMove();
            PlayerRotate();
        }
        private void PlayerMove()
        {
            transform.position += new Vector3(_horizontal * _moveSpeed * Time.deltaTime, 0, _vertical * _moveSpeed * Time.deltaTime);

        }
        private void PlayerRotate()
        {
            _playerDirection = Vector3.forward * _vertical + Vector3.right * _horizontal;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_playerDirection), _rotateSpeed * Time.deltaTime);
        }
        #endregion
    }
}