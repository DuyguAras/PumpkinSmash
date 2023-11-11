using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    
    public class SnakeBallMovement : MonoBehaviour
    {
        [SerializeField] private float ballSpeed = 5f;

        void Update()
        {
            if (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Start)
            {
                transform.Translate(Vector3.back * ballSpeed * Time.deltaTime);
            }
            
            
        }
    }
}
