using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Dungeon
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Doorway : MonoBehaviour
    {
        public bool IsLocked { get; private set; }
        public bool IsOpen { get; private set; }
        
        private BoxCollider2D _collider;
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField, Required] private Sprite _closedTexture;
        [SerializeField, Required] private Sprite _openTexture;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Lock()
        {
            _collider.enabled = true;
            _spriteRenderer.sprite = _closedTexture;
            IsLocked = true;
            IsOpen = false;
        }

        public void UnLock()
        {
            _collider.enabled = false;
            _spriteRenderer.sprite = _openTexture;
            IsLocked = false;
            IsOpen = true;
        }
    }
}