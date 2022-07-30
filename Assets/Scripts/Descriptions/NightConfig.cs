using UnityEngine;
using UnityEngine.UI;

namespace StayFast
{
    [CreateAssetMenu(fileName = "NightConfig", menuName = "Descriptions/NightConfig")]
    public class NightConfig : ScriptableObject, IDaysConfigs
    {
        [SerializeField] private string nightImageString;
        [SerializeField] private string tubeString;
        [SerializeField] private string massageString;


        private Sprite tubeSprite;
        private Sprite massageSprite;
        private NightView _animator;

        public Sprite TubeSprite
        {
            get
            {
                if (tubeSprite == null)
                    tubeSprite = Loader.Load<Sprite>("Sprites/" + tubeString);
                return tubeSprite;
            }
        }
        
        public Sprite MassageSprite
        {
            get
            {
                if (massageSprite == null)
                    massageSprite = Loader.Load<Sprite>("Sprites/" + massageString);
                return massageSprite;
            }
        }

        public NightView Loading(Transform canvas)
        {
            if (_animator == null)
            {
                var image = Loader.Load<Image>(nightImageString);
                var instant = Instantiate(image, canvas);
                _animator = instant.GetComponent<NightView>();
                return _animator;
            }

            return _animator;
        }

    }
}