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
            var locator = instantiate.Instant(_allDescriptions.SoundLocator.gameObject, new GameObject("SoundLocator").transform);

            _soundLocator = locator.GetComponent<SoundLocator>();
            _soundLocator.Init();
            Sounding.Init(_soundLocator.AudioDictionary);

            // нужен спаун-контроллер, и класс, который бы собирал ChangeDaysController
            _changeDaysFactory = new ChangeDaysFactory(allDescriptions, instantiate, input, coroutine, _profilePlayer);
            _changeDays = _changeDaysFactory.CreateController();
            _globalDays = new GlobalDaysController(allDescriptions, coroutine, _changeDays);

            _changeDays.StartMessage();
            
            
            
            // _soundLocator.PlayAudio(ClipType.Ambience);

        }

        public void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Game:
                    _coroutine.Starting(_globalDays.Timer());
                    Debug.Log("Здесь запускаем основную механику");
                    MainMechanic.AnimationGO();
                    Sounding.PlayAudio(ClipType.Soft);
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