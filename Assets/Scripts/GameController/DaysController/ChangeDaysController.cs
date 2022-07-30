using UnityEngine;

namespace StayFast
{
    public class ChangeDaysController : BaseController
    {
        // знает о тех, кого меняет
        private Animation _changingDays;
        private TubeView _tube;
        private MassageView _currentMassage;
        
        public ChangeDaysController()
        {
            
        }

        public void ChangeDays(IDaysConfigs configs)
        {
            // вот тут каверзная анимация, блин, не работал с ними никогда...
            _tube.SetSprite(configs.TubeSprite);
        }
    }
}