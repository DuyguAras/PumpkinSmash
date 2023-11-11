using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Games.GameName
{
    public class MenuUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;
        public void GameSettings(bool isMenu)
        {
            if (isMenu)
            {
                mainMenuPanel.SetActive(true);
                settingsPanel.SetActive(false);
            }
            else
            {
                settingsPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
            }
            
        }
    }
}
