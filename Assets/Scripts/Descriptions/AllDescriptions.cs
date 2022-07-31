using UnityEngine;

namespace StayFast
{
    [CreateAssetMenu(fileName = "AllDescriptions", menuName = "Descriptions/AllDescriptions")]
    public class AllDescriptions : ScriptableObject
    {
        [SerializeField] private NightConfig nightConfig;
        [SerializeField] private TubeConfig tubeConfig;
        [SerializeField] private DaysConfig daysConfig;

        public NightConfig NightConfig => nightConfig;
        public TubeConfig TubeConfig => tubeConfig;
        public DaysConfig DaysConfig => daysConfig;
    }
}