using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void Playclicked()
        {
            GameManager.Instance.LoadLevelScene();
        }
        public void ExitClicked()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

