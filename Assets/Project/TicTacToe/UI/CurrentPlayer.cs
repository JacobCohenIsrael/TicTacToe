using JCI.Core.Models;
using TMPro;
using UnityEngine;

namespace Project.TicTacToe.UI
{
    public class CurrentPlayer : MonoBehaviour
    {
        [SerializeField] private StringVar currentPlayer;
        [SerializeField] private TextMeshProUGUI currentPlayerText;
        
        private void Awake()
        {
            currentPlayer.Updated += OnCurrentPlayerUpdate;
        }

        private void OnDestroy()
        {
            currentPlayer.Updated -= OnCurrentPlayerUpdate;
        }

        private void OnCurrentPlayerUpdate(string markType)
        {
            //TODO: change to dictionary key for localization and replace with proper value 
            currentPlayerText.text = $"Current Player: {markType}";
        }
    }
}