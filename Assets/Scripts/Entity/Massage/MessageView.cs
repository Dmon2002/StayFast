using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace StayFast
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MessageView : MonoBehaviour
    {
        // [SerializeField] private Animator _animator;
        private Transform _transform;
        public SpriteRenderer render;

        public Transform position => _transform;

        // public Animator animator => _animator;

        private void Start()
        {

            // _animator.enabled = false;
            _transform = gameObject.transform;
            /*showMassage = gameObject.GetComponent<Animator>();
            render = gameObject.GetComponent<SpriteRenderer>();*/
        }

        public void SetPosition(Vector3 vector)
        {
            _transform.position = vector;
        }

        public void SetSprite(Sprite sprite)
        {
            render.sprite = sprite;
        }
    }
}