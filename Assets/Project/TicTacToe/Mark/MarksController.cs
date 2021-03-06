using JCI.Core.Events;
using JCI.Core.Models;
using UnityEngine;

namespace Project.TicTacToe.Mark
{
    public class MarksController : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Color lineColor;
        [SerializeField] private LayerMask marksLayerMask;
        [SerializeField] private MarkView[] marks;
        [SerializeField] private float hitRadius;

        [SerializeField] private GameEvent gameOverEvent;
        
        [SerializeField] private StringVar currentMarkType;
        [SerializeField] private BoolVar humanTurn;
        
        private Camera _mainCamera;
        private int _marksCount;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update () {
            if (humanTurn && Input.GetMouseButtonUp (0)) {
                Vector2 touchPosition = _mainCamera.ScreenToWorldPoint (Input.mousePosition) ;

                Collider2D hit = Physics2D.OverlapCircle (touchPosition, hitRadius, marksLayerMask) ;

                if (hit) //mark is touched.
                    HitMark (hit.GetComponent <MarkView> ()) ;
            }
        }
        
        private void HitMark (MarkView markView) {
            if (!markView.isMarked) {
                markView.SetMark(currentMarkType);
                _marksCount++ ;
                var won = CheckIfWin () ;
                if (won) {
                    gameOverEvent.Raise();
                    return;
                }
                
                if (_marksCount == 9) 
                {
                    gameOverEvent.Raise();
                    return;
                }
                
                SwitchPlayer();
            }
        }

        private void SwitchPlayer()
        {
            currentMarkType.SetValue(currentMarkType == MarkType.X ? MarkType.O : MarkType.X);
        }
        
        private bool CheckIfWin () {
            return
                IsMatched (0, 1, 2) || IsMatched (3, 4, 5) || IsMatched (6, 7, 8) ||
                IsMatched (0, 3, 6) || IsMatched (1, 4, 7) || IsMatched (2, 5, 8) ||
                IsMatched (0, 4, 8) || IsMatched (2, 4, 6);

        }

        private bool IsMatched (int i, int j, int k) {
            var markType = currentMarkType ;
            var matched = marks [i].markType == markType && marks [j].markType == markType && marks [k].markType == markType;

            if (matched)
                DrawLine (i, k);

            return matched;
        }
        
        private void DrawLine (int i, int k) {
            lineRenderer.SetPosition (0, transform.GetChild (i).position);
            lineRenderer.SetPosition (1, transform.GetChild (k).position);
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.enabled = true;
        }
    }
}