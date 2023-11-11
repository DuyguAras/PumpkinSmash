using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class BallEndingSpawn : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
