using Core.Games.GameName.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class BallTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem correctParticle;
        [SerializeField] private ParticleSystem wrongParticle;

        AudioManager audioManager;
        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Respawn"))
            {
                audioManager.PlaySFX(audioManager.explosionSound);
                Instantiate(wrongParticle, transform.position, Quaternion.identity);
                Destroy(this.gameObject); 
            }

            if (other.GetComponent<SnakeBallID>() != null)
            {
                if (GetComponent<BallID>().ballID == other.GetComponent<SnakeBallID>().snakeBallID)
                {
                    audioManager.PlaySFX(audioManager.hitSound);
                    Instantiate(correctParticle, transform.position, Quaternion.identity);
                    EventBus<RaiseScoreEvent>.Emit(this, new RaiseScoreEvent());
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    audioManager.PlaySFX(audioManager.explosionSound);
                    EventBus<HealthCounterEvent>.Emit(this, new HealthCounterEvent());
                    Instantiate(wrongParticle, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
                
                
            }
            
        }
        
    }
}
