using JCI.Core.Events;
using JCI.Core.Models;
using Project.TicTacToe.Mark;
using RSG;
using UnityEngine;

namespace Project.TicTacToe.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StringVar currentPlayer;
        [SerializeField] private BoolVar humanTurn;
        [SerializeField] private GameEvent gameOverEvent;
        private void Awake()
        {
            Initialize();
        }

        private IPromise Initialize()
        {
            currentPlayer.SetAndNotify(MarkType.X);
            humanTurn.SetAndNotify(true);
            gameOverEvent.RegisterListener(OnGameOver);
            return Promise.Resolved();
        }

        private void OnDestroy()
        {
            gameOverEvent.UnregisterListener(OnGameOver);
        }

        private void OnGameOver()
        {
            humanTurn.SetAndNotify(false);
        }
    }
}