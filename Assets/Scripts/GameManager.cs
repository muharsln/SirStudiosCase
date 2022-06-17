using UnityEngine;

namespace SirStudiosCase
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake() => Instance = this;
        public enum GameState
        {
            Play,
            Start,
            Finish
        }
        public GameState state;

        public void SetGameState(GameState gameState)
        {
            state = gameState;
        }

        public GameState ReturnGameState()
        {
            return state;
        }
    }
}