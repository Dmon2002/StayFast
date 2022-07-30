using UnityEngine;

namespace StayFast
{
    [CreateAssetMenu(fileName = "DaysConfig", menuName = "Descriptions/DaysConfig")]
    public class DaysConfig : ScriptableObject, IDaysConfigs
    {
        [SerializeField] private Sprite tubeSprite;
        [SerializeField] private Sprite massageSprite;


        public Sprite TubeSprite { get; }
        public Sprite MassageSprite { get; }
    }
}