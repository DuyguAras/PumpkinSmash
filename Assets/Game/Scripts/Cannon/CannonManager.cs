using Core.Games.GameName.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class CannonManager : MonoBehaviour
    {   
        [Header("Cannon Settings")]
        [SerializeField] private float rotSpeed = 10f;
        [SerializeField] private float minRot = -30f;
        [SerializeField] private float maxRot = 30f;
        private void OnEnable()
        {
            EventBus<GamePrepareEvent>.AddListener(SetCannonRotation);
        }
        private void OnDisable()
        {
            EventBus<GamePrepareEvent>.RemoveListener(SetCannonRotation);
        }

        void Update()
        {
            if (GameStateManager.Instance.currentGameState == GameStateManager.GameState.Start)
            {
                float horizontalAxis = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.up * horizontalAxis * rotSpeed * Time.deltaTime);
            }
            
        }
        private void SetCannonRotation(object sender, GamePrepareEvent e)
        {
            transform.rotation = Quaternion.Euler(0, 0, -15);
        }
    }
}
