using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Abstract.Utilities;
using TMPro;

namespace Meliora08_04_2023.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {
        [SerializeField] int player1Score = 100;
        [SerializeField] int player2Score = 100;
        [SerializeField] TextMeshProUGUI player1ScoreText;
        [SerializeField] TextMeshProUGUI player2ScoreText;
        [SerializeField] TextMeshProUGUI _player1Name;
        [SerializeField] TextMeshProUGUI _player2Name;

        public bool isPlayer1Turn = true;

        private void Awake()
        {
            SingletonThisGameObject(this);
            UpdateScoreText();
        }

        public void AddScore(int points)
        {
            if (isPlayer1Turn)
            {
                player1Score -= points;
            }
            else
            {
                player2Score -= points;
            }
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            player1ScoreText.text = player1Score.ToString();
            player2ScoreText.text = player2Score.ToString();
        }

        public void ChangePlayersTurn()
        {
            isPlayer1Turn = !isPlayer1Turn;
        }
    }
}

