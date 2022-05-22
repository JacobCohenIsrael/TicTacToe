using System;
using JCI.Core.Inspector;
using JCI.Core.Models;
using UnityEngine;

namespace Project.TicTacToe.Mark
{
    [CreateAssetMenu(menuName = "TicTacToe/Mark/MarksByType", fileName = "MarksByType")]
    public class MarkSpritesByType : ScriptableList<MarkByType>
    {
        
    }

    [Serializable]
    public class MarkByType : IIdentifiable
    {
        [StringInList(typeof(MarkType))]
        public string type;

        public Sprite sprite;
        
        public string Id => type;
    }
}