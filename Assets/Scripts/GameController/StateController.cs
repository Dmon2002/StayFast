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
        

        public StateController(InputController input, AllDescriptions allDescriptions, Transform canvas, 
            CoroutineSystem coroutine, MonoFactory instantiate)
        {
            _input = input;
            _allDescriptions = allDescriptions;
            _profilePlayer = new ProfilePlayer();
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            
            // нужен спаун-контроллер, и класс, который бы собирал ChangeDaysController
            _changeDaysFactory = new ChangeDaysFactory(allDescriptions, instantiate, input, coroutine);
            _changeDays = _changeDaysFactory.CreateController();
            _globalDays = new GlobalDaysController(allDescriptions, coroutine, _changeDays);

            coroutine.Starting(_globalDays.Timer());

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
                    //
                    break;
                case GameState.ChangeDays:
                    break;
            }
        }

        protected override void OnDispose()
        {
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
        }
    }

    public class ChangeDaysFactory
    {
        private AllDescriptions description;
        private MonoFactory instantiate;
        private InputController input;
        private CoroutineSystem _coroutine;

        public ChangeDaysFactory(AllDescriptions description, MonoFactory instantiate, 
            InputController input, CoroutineSystem coroutine)
        {
            this.description = description;
            this.instantiate = instantiate;
            this.input = input;
            _coroutine = coroutine;
        }

        public ChangeDaysController CreateController()
        {
            var nightView = description.NightConfig.NightView;
            var tube = description.NightConfig.TubeSprite;
            var massage = description.NightConfig.MessageView;
            var result = new ChangeDaysController(nightView, tube, massage, input, _coroutine);

            return result;
        }
    }
}