using Core.Games.GameName.EventBus;
using UnityEngine;
using TMPro;

namespace Core.Games.GameName
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int scoreCounter;

        [SerializeField] private GameObject preparePanel;
        [SerializeField] private GameObject gameStartPanel;
        [SerializeField] private GameObject gameOverPanel;
        
        private void OnEnable()
        {
            EventBus<GameStartEvent>.AddListener(GameStart);
            EventBus<GameNextLevelEvent>.AddListener(GameNextLevel);
            EventBus<GameRestartLevelEvent>.AddListener(GameRestartLevel);
            EventBus<GameOverEvent>.AddListener(GameOver);
            EventBus<GameEndEvent>.AddListener(GameEnd);
            EventBus<GamePrepareEvent>.AddListener(GamePrepare);
            EventBus<RaiseScoreEvent>.AddListener(RaiseScore);
        }

        private void OnDisable()
        {
            EventBus<GameStartEvent>.RemoveListener(GameStart);
            EventBus<GameNextLevelEvent>.RemoveListener(GameNextLevel);
            EventBus<GameRestartLevelEvent>.RemoveListener(GameRestartLevel);
            EventBus<GameOverEvent>.RemoveListener(GameOver);
            EventBus<GameEndEvent>.RemoveListener(GameEnd);
            EventBus<GamePrepareEvent>.RemoveListener(GamePrepare);
            EventBus<RaiseScoreEvent>.RemoveListener(RaiseScore);
        }
       
        private void GamePrepare(object sender, GamePrepareEvent e)
        {
            if (preparePanel)
            {
                preparePanel.SetActive(true);
            }

            gameOverPanel.SetActive(false);
            gameStartPanel.SetActive(false);
            
            scoreCounter = 0;
            scoreText.text = "Score: " + scoreCounter;
        }

        private void GameStart(object sender, GameStartEvent e)
        {
            gameStartPanel.SetActive(true);
            preparePanel.SetActive(false);
        }
        
        private void GameNextLevel(object sender, GameNextLevelEvent e)
        {
            
        }
        
        private void GameRestartLevel(object sender, GameRestartLevelEvent e)
        {
            
        }
        
        private void GameOver(object sender, GameOverEvent e)
        {
            gameStartPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }

        private void GameEnd(object sender, GameEndEvent e)
        {
            
        }
        private void RaiseScore(object sender, RaiseScoreEvent e)
        {
            scoreCounter += 100;
            scoreText.text = "Score: " + scoreCounter;
        }
        
       
    }
}
