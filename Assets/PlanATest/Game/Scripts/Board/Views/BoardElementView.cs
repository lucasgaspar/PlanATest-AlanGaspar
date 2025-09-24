using PlanATest.Game.Board.Data;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace PlanATest.Game.Board.View
{
    public class BoardElementView : MonoBehaviour, IPoolable<BoardElementData, Vector2Int>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _sizeX = 1f;
        [SerializeField] private float _sizeY = 1f;
        [SerializeField] private float _offsetX = 0f;
        [SerializeField] private float _offsetY = 0f;

        [Inject] private Pool _gridElementViewPool;

        [SerializeField] private UnityEvent _onClicked;

        private BoardElementData _elementData;
        private Vector2Int _position;
        private BoardView _boardView;

        public void OnSpawned(BoardElementData elementData, Vector2Int position)
        {
            _elementData = elementData;
            _position = position;
            gameObject.SetActive(true);
            _spriteRenderer.sprite = _elementData.Sprite;
            _spriteRenderer.sortingOrder = _position.y;
            transform.position = GetTransformedPosition(_position);
        }

        public void SetBoardView(BoardView boardView)
        {
            _boardView = boardView;
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
        }

        public void Destroy()
        {
            _gridElementViewPool.Despawn(this);
        }

        public Vector2Int GetPosition()
        {
            return _position;
        }

        public void MoveToPosition(Vector2Int newPosition)
        {
            _position = newPosition;
            _spriteRenderer.sortingOrder = _position.y;
            transform.position = GetTransformedPosition(_position);
        }

        private Vector3 GetTransformedPosition(Vector2Int position)
        {
            return new Vector3(position.x * _sizeX + _offsetX, position.y * _sizeY + _offsetY, 0);
        }

        private void OnMouseUpAsButton()
        {
            if (_boardView != null && _boardView.IsMovingPieces)
            {
                return;
            }

            _onClicked?.Invoke();
        }

        public class Pool : PoolableMemoryPool<BoardElementData, Vector2Int, BoardElementView> { }
    }
}
