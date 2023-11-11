using Core.Games.GameName.EventBus;
using UnityEngine;

namespace Core.Games.GameName
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int hitCount = 3;
        [SerializeField] private GameObject[] hearts;
        private void OnEnable()
        {
            EventBus<GameStartEvent>.AddListener(GameStart);
            EventBus<GameNextLevelEvent>.AddListener(GameNextLevel);
            EventBus<GameRestartLevelEvent>.AddListener(GameRestartLevel);
            EventBus<GameOverEvent>.AddListener(GameOver);
            EventBus<GameEndEvent>.AddListener(GameEnd);
            EventBus<HealthCounterEvent>.AddListener(HealthCounter);
            EventBus<GamePrepareEvent>.AddListener(GamePrepare);
        }

        private void OnDisable()
        {
            EventBus<GameStartEvent>.RemoveListener(GameStart);
            EventBus<GameNextLevelEvent>.RemoveListener(GameNextLevel);
            EventBus<GameRestartLevelEvent>.RemoveListener(GameRestartLevel);
            EventBus<GameOverEvent>.RemoveListener(GameOver);
            EventBus<GameEndEvent>.RemoveListener(GameEnd);
            EventBus<HealthCounterEvent>.RemoveListener(HealthCounter);
            EventBus<GamePrepareEvent>.RemoveListener(GamePrepare);
        }

        private void Start()
        {
            EventBus<GamePrepareEvent>.Emit(this, new GamePrepareEvent());
        }

        private void GameStart(object sender, GameStartEvent e)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Start);
        }

        private void GameNextLevel(object sender, GameNextLevelEvent e)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.NextLevel);
        }

        private void GameRestartLevel(object sender, GameRestartLevelEvent e)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.RestartLevel);
        }

        private void GameOver(object sender, GameOverEvent e)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.Over);
        }

        private void GameEnd(object sender, GameEndEvent e)
        {
            GameStateManager.Instance.SetGameState(GameStateManager.GameState.End);
        }
        private void HealthCounter(object sender, HealthCounterEvent e)
        {
            hitCount--;
            if (hitCount == 0)
            {
                EventBus<GameOverEvent>.Emit(this, new GameOverEvent());
            }
            if (hitCount < hearts.Length)
            {
                hearts[hitCount].SetActive(false);
            }
        }
        private void GamePrepare(object sender, GamePrepareEvent e)
        {
            hitCount = 3;

            for (int i = 0; i < hearts.Length; i++)
                hearts[i].SetActive(true);

        }
    }
}