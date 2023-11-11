using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class BackupBallM : MonoBehaviour
    {
        [SerializeField] private List<GameObject> ballList;
        private GameObject previousBall;

        void Start()
        {
            BallSpawn();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                if (previousBall != null)
                {
                    if (previousBall.GetComponent<FireBallMovement>() != null)
                    {
                        previousBall.GetComponent<FireBallMovement>().enabled = true;
                        previousBall.transform.SetParent(null);
                    }
                    Invoke("BallSpawn", 1);
                }
                
            }
            
        }
        public void BallSpawn()
        {
            int randomValue = Random.Range(0, ballList.Count);
            previousBall = Instantiate(ballList[randomValue], transform.position, transform.rotation, transform);

            previousBall.transform.localScale /= 1.7f;
            
        }
    }
}
