using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class FireBallMovement : MonoBehaviour
    {
        [SerializeField] private float ballSpeed = 10.0f;
        private void Start()
        {
            Destroy(gameObject, 7);
        }
        void Update()
        {
            BallMove();
        }
        private void BallMove()
        {
            Vector3 localForward = transform.TransformDirection(Vector3.right);
            transform.position += localForward * ballSpeed * Time.deltaTime;
        }
        
    }
}
