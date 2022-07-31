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
<<<<<<< Updated upstream
=======
        private SoundDescriptions _soundDescriptions;
>>>>>>> Stashed changes
        

        public StateController(InputController input, AllDescriptions allDescriptions, Transform canvas, 
            CoroutineSystem coroutine, MonoFactory instantiate)
        {
            _input = input;
            _allDescriptions = allDescriptions;
            _coroutine = coroutine;
            _profilePlayer = new ProfilePlayer();
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
<<<<<<< Updated upstream
            
=======

            _soundDescriptions = _allDescriptions.SoundDescriptions;
            _soundDescriptions.Init();
            Sounding.Init(_soundDescriptions.AudioDictionary);
>>>>>>> Stashed changes
            // нужен спаун-контроллер, и класс, который бы собирал ChangeDaysController
            _changeDaysFactory = new ChangeDaysFactory(allDescriptions, instantiate, input, coroutine, _profilePlayer);
            _changeDays = _changeDaysFactory.CreateController();
            _globalDays = new GlobalDaysController(allDescriptions, coroutine, _changeDays);

            _profilePlayer.CurrentState.Value = GameState.Game;

        }

        public void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Game:
                    _coroutine.Starting(_globalDays.Timer());
                    Debug.Log("Здесь запускаем основную механику");
<<<<<<< Updated upstream
=======
                    Sounding.PlayAudio(ClipType.Soft);
                    MainMechanic.AnimationGO();
>>>>>>> Stashed changes
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