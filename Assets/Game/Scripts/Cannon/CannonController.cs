using Core.Games.GameName.EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class CannonController : MonoBehaviour
    {
        
        private void OnEnable()
        {
            EventBus<CannonControlEvent>.AddListener(MoveCannon);
        }
        private void OnDisable()
        {
            EventBus<CannonControlEvent>.RemoveListener(MoveCannon);
        }
        private void MoveCannon(object sender, CannonControlEvent e)
        {
          
        }
    }
}
