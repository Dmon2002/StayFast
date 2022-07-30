using UnityEngine;

namespace StayFast
{
    [CreateAssetMenu(fileName = "AllDescriptions", menuName = "Descriptions/AllDescriptions")]
    public class AllDescriptions : ScriptableObject
    {
        [SerializeField] private NightConfig nightConfig;

        public NightConfig NightConfig => nightConfig;
    }
}