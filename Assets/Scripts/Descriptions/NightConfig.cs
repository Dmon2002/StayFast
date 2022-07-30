using UnityEngine;
using UnityEngine.UI;

namespace StayFast
{
    [CreateAssetMenu(fileName = "NightConfig", menuName = "Descriptions/NightConfig")]
    public class NightConfig : ScriptableObject
    {
        [SerializeField] private string nightImageString;

        private Animator _animator;

        public Animator Loading(Transform canvas)
        {
            if (_animator == null)
            {
                var image = Loader.Load<Image>(nightImageString);
                var instant = Instantiate(image, canvas);
                _animator = instant.GetComponent<Animator>();
                return _animator;
            }

            return _animator;
        }

        public void testingAnimation(Transform canvas)
        {
            Debug.Log($"Мы зашли в анимацию");
            var animator = Loading(canvas);
            animator.enabled = true;
            animator.Play("New State");
            Debug.Log("Мы это написали не дожидаясь конца анимации, верно?");
        }
    }
}