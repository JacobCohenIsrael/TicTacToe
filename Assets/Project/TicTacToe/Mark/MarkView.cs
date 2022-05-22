using JCI.Core.Inspector;
using UnityEngine;

namespace Project.TicTacToe.Mark
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class MarkView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private CircleCollider2D circleCollider2D;
        [SerializeField] private MarkSpritesByType marksByType;
        [StringInList(typeof(MarkType))]
        [SerializeField] public string markType = MarkType.None;

        [SerializeField] public bool isMarked = false;

        public void SetMark(string markType)
        {
            // Handle undefined mark type, for now let's assume it exists
            spriteRenderer.sprite = marksByType[markType].sprite;
            isMarked = true;
            this.markType = markType;
            
            // Avoid double click
            circleCollider2D.enabled = false;
        }
    }
}

