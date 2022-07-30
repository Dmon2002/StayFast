using System;
using UnityEngine;

namespace StayFast
{
    public class MassageView : MonoBehaviour
    {
        public Animator showMassage;

        private SpriteRenderer renferer;
        private Sprite currentSprite;

        private void Awake()
        {
            showMassage = GetComponent<Animator>();
            renferer = GetComponent<SpriteRenderer>();
            currentSprite = renferer.sprite;
        }

        public void SetSprite(Sprite sprite)
        {
            currentSprite = sprite;
        }
    }
}