using Core.Games.GameName.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class SnakeBallManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] ballPrefabs;
        [SerializeField] private List<GameObject> ballList;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnInterval = 1f;
        private void Start()
        {
            ballList = new();
        }
        private void OnEnable()
        {
            EventBus<GameStartEvent>.AddListener(SetActiveSpawnBall);
        }
        private void OnDisable()
        {
            EventBus<GameStartEvent>.RemoveListener(SetActiveSpawnBall);
        } 
        IEnumerator SpawnBall()
        {
            while (true)
            {
                int randomPrefabIndex = Random.Range(0, ballPrefabs.Length);
                GameObject selectedPrefab = ballPrefabs[randomPrefabIndex];
                GameObject newBall = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
                ballList.Add(newBall);
                yield return new WaitForSeconds(spawnInterval);
                if (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Over)
                { 
                    break;
                }
                
            }
        }
        private void SetActiveSpawnBall(object sender, GameStartEvent e)
        {
            StartCoroutine(SpawnBall());
        }
        public void RestartGame()
        {
            int listCount = ballList.Count;
            for (int i = 0; i <listCount; i++)
            {
                Destroy(ballList[0]);
                ballList.RemoveAt(0);
            }
            
            EventBus<GamePrepareEvent>.Emit(this, new GamePrepareEvent());
        }
    }
}

