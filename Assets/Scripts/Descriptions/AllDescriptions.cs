using UnityEngine;

namespace StayFast
{
    [CreateAssetMenu(fileName = "AllDescriptions", menuName = "Descriptions/AllDescriptions")]
    public class AllDescriptions : ScriptableObject
    {
        [SerializeField] private NightConfig nightConfig;
        [SerializeField] private TubeConfig tubeConfig;
        [SerializeField] private DaysConfig daysConfig;
        [SerializeField] private WithoutFunction _background;
<<<<<<< Updated upstream
=======
        [SerializeField] private SoundDescriptions soundDescriptions;
>>>>>>> Stashed changes

        public NightConfig NightConfig => nightConfig;
        public TubeConfig TubeConfig => tubeConfig;
        public DaysConfig DaysConfig => daysConfig;
<<<<<<< Updated upstream
=======

        public SoundDescriptions SoundDescriptions => soundDescriptions;
>>>>>>> Stashed changes
    }
}