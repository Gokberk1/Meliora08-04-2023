using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void PlayAgainClicked()
        {
            GameManager.Instance.LoadLevelScene();
        }
        public void GoToMenuClicked()
        {
            GameManager.Instance.LoadMenuScene();
        }
    }
}

