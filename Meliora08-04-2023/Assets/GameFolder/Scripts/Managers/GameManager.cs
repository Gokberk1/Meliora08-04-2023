using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Meliora08_04_2023.Abstract.Utilities;


namespace Meliora08_04_2023.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {
        public event System.Action OnGameOver;

        private void Awake()
        {
            SingletonThisGameObject(this);
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }

        public void LoadLevelScene()
        {
            StartCoroutine(LoadLevelSceneAsync());
        }
        public void LoadMenuScene()
        {
            StartCoroutine(LoadMenuSceneAsync());
        }
        IEnumerator LoadLevelSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("GameScene");
        }
        IEnumerator LoadMenuSceneAsync()
        {
            yield return SceneManager.LoadSceneAsync("MenuScene");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}

