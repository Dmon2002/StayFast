
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

        public StateController(InputController input, AllDescriptions allDescriptions)
        {
            _input = input;
            _allDescriptions = allDescriptions;
            _profilePlayer = new ProfilePlayer();
            _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            
            
            
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
}