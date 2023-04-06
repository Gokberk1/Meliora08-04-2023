using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Meliora08_04_2023.Abstract.Utilities;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] int player1Score = 100;
        [SerializeField] int player2Score = 100;
        [SerializeField] TextMeshProUGUI _player1ScoreTxt;
        [SerializeField] TextMeshProUGUI _player2ScoreTxt;
        [SerializeField] TextMeshProUGUI _player1Name;
        [SerializeField] TextMeshProUGUI _player2Name;

        public bool isPlayer1Turn = true;

        private void Awake()
        {
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
            if (player1Score <= 0)
            {
                player1Score = 0;
                GameManager.Instance.GameOver();
            }
            if (player2Score <= 0)
            {
                player2Score = 0;
                GameManager.Instance.GameOver();
            }
            _player1ScoreTxt.text = player1Score.ToString();
            _player2ScoreTxt.text = player2Score.ToString();
        }

        public void ChangePlayersTurn()
        {
            isPlayer1Turn = !isPlayer1Turn;
        }
    }
}

