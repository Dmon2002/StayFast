using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class ChangeDaysController : BaseController
    {
        // знает о тех, кого меняет
        private NightView _changingDays;
        private TubeView _tube;
        private MassageView _currentMassage;
        
        public ChangeDaysController(NightView changingDays)
        {
            _changingDays = changingDays;
            _changingDays.OnEndNight += OnEndNight;
            // должны идентифицировать и создать эту пробирку где-то
        }

        public void ChangeDays(IDaysConfigs configs)
        {
            _changingDays.Sleeping.Play("New State");

            // _tube.SetSprite(configs.TubeSprite);
            _changingDays.enabled = false;
        }

        public void OnEndNight()
        {
            Debug.Log("Мы зашли в конец ночи, показываем анимацию сообщения");
            _currentMassage.showMassage.Play("");
                
        }
    }
}