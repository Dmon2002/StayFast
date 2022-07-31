using Unity.VisualScripting;
using UnityEngine;

namespace StayFast
{
    public class StateController : BaseController
    {
        private readonly InputController _input;
        private readonly AllDescriptions _allDescriptions;
        private readonly ProfilePlayer _profilePlayer;
        private GlobalMoveController _globalMove;
        private GamePlayController _gamePlay;
        private ChangeDaysController _changeDays;
        private GlobalDaysController _globalDays;
        private ChangeDaysFactory _changeDaysFactory;
        private CoroutineSystem _coroutine;
        private SoundLocator _soundLocator;
        

        public StateController(InputController input, AllDescriptions allDescriptions, Transform canvas, 
            CoroutineSystem coroutine, MonoFactory instantiate)
        {
            _input = input;
            _allDescriptions = allDescriptions;
            _coroutine = coroutine;
            _profilePlayer = new ProfilePlayer();
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);

            _soundLocator = _allDescriptions.SoundLocator;
            _soundLocator.Init();
            // нужен спаун-контроллер, и класс, который бы собирал ChangeDaysController
            _changeDaysFactory = new ChangeDaysFactory(allDescriptions, instantiate, input, coroutine, _profilePlayer);
            _changeDays = _changeDaysFactory.CreateController();
            _globalDays = new GlobalDaysController(allDescriptions, coroutine, _changeDays);

            _changeDays.StartMessage();
            
            
            
            // _soundLocator.PlayAudio(ClipType.Ambience);

        }


        private void StartState()
        {
            _profilePlayer.CurrentState.Value = GameState.Loading;
        }

        public void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Game:
                    _coroutine.Starting(_globalDays.Timer());
                    Debug.Log("Здесь запускаем основную механику");
                    _soundLocator.PlayAudio(ClipType.Soft);
                    MainMechanic.AnimationGO();
                    break;
                case GameState.End:
                    Debug.Log("Запускаем финальное видео");
                    break;
            }
        }

        protected override void OnDispose()
        {
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        }
    }
}