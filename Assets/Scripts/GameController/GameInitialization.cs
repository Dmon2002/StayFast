namespace StayFast
{
    public class GameInitialization
    {
        public GameInitialization(UpdateController update, AllDescriptions descriptions)
        {
            var input = new InputController();
            var stateController = new StateController(input, descriptions);

            update.Add(input);
        }
    }
}