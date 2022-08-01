using System.Collections;
using UnityEngine;

namespace StayFast
{
    public class ChangeDaysController : BaseController
    {
        private readonly InputController _input;
        private NightView _nightView;
        private TubeView _tube;
        private MessageView _currentMessage;
        private CoroutineSystem _coroutine;
        private readonly ProfilePlayer _profile;
        
        private int counter;
        private const float speed = 3f;
        
        public ChangeDaysController(NightView nightView, TubeView tube, MessageView messageView, 
            InputController input, CoroutineSystem coroutine, ProfilePlayer profile)
        {
            _nightView = nightView;
            _tube = tube;
            _currentMessage = messageView;
            _input = input;
            _coroutine = coroutine;
            _profile = profile;
            
            _nightView.OnEndNight += StartMessage;
        }

        public IEnumerator ChangeDays(Sprite tube, Sprite massage)
        {
            counter++;
            _nightView.gameObject.SetActive(true);
            _nightView.Sleeping.enabled = true;
            yield return new WaitForSeconds(0.5f);              //todo магическое число
                
            /*
            _currentMessage - это блокнот. Ему можно добавлять свойства и изменять их здесь при перемене дей
            _currentMessage.SetSprite(massage);
            */

            
        }

        public void StartMessage()
        {
            _coroutine.Starting(OnEndNight());
        }

        public IEnumerator OnEndNight()
        {
            
            _nightView.Sleeping.enabled = false;
            _currentMessage.gameObject.SetActive(true);

            while (_currentMessage.gameObject.transform.position.y < -3.30)
            {
                _currentMessage.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
                yield return null;
                
            }
            
            _input.OnLeftMouseDown += AfterInput;
        }

        public void AfterInput()
        {
            Debug.Log("Мы закрываемся");
            _input.OnLeftMouseDown -= AfterInput;
            _coroutine.Starting(CloseMessage());
        }

        public IEnumerator CloseMessage()
        {
            while (_currentMessage.position.position.y > -8)
            {
                _currentMessage.position.Translate(0, -speed * Time.deltaTime, 0);
                yield return null;
            }
            _currentMessage.gameObject.SetActive(false);
            _coroutine.StopAllCoroutine();

            //MainMechanic.NewDay();
            GameObject.FindGameObjectWithTag("qwe").GetComponent<MainMechanic>().NewDay();

            if (counter == 3)
            {
                _profile.CurrentState.Value = GameState.End;
            }
            
            if(counter < 3)
                _profile.CurrentState.Value = GameState.Game;
        }
    }
}