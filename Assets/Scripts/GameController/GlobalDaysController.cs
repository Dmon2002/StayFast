using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class GlobalDaysController : BaseController
    {
        private readonly ChangeDaysController _daysController;

        private Stack<Sprite> tubeStack;
        private Stack<Sprite> massageStack;
        private CoroutineSystem _coroutine;

        public GlobalDaysController(AllDescriptions descriptions, CoroutineSystem coroutine, ChangeDaysController daysController)
        {
            tubeStack = descriptions.DaysConfig.TubeSprite;
            massageStack = descriptions.DaysConfig.MassageSprite;
            _coroutine = coroutine;
            
            _daysController = daysController;
        }

        public IEnumerator Timer()
        {
            int count = 0;

            while (count < 2)
            {
                yield return new WaitForSeconds(1);
                count++;
                Debug.Log($"Прошло секунд {count}");
                // todo здесь отображаем время на UI
            }

            var tube = tubeStack.Pop();
            var massage = massageStack.Peek();

            _coroutine.Starting(_daysController.ChangeDays(tube, massage));
        }

        public void TestVoid()
        {
            
        }
    }
}