using Core.Games.GameName.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core.Games.GameName
{
    public class SpawnBallInteraction : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                EventBus<GameOverEvent>.Emit(this, new GameOverEvent());
                Destroy(gameObject);
            }
        }
    }
}
