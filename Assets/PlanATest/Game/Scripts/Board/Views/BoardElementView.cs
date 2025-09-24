using PlanATest.Game.Board.Data;
using UnityEngine;
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

        private BoardElementData _elementData;
        private Vector2Int _position;

        public void OnSpawned(BoardElementData elementData, Vector2Int position)
        {
            _elementData = elementData;
            _position = position;
            gameObject.SetActive(true);
            _spriteRenderer.sprite = _elementData.Sprite;
            _spriteRenderer.sortingOrder = position.y;
            transform.localPosition = new Vector3(_position.x * _sizeX + _offsetX, _position.y * _sizeY + _offsetY, 0);
        }

        public void OnDespawned()
        {
            gameObject.SetActive(false);
        }

        public void Destroy()
        {
            _gridElementViewPool.Despawn(this);
        }

        public class Pool : PoolableMemoryPool<BoardElementData, Vector2Int, BoardElementView> { }
    }
}
