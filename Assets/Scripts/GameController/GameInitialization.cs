namespace StayFast
{
    public class GameInitialization
    {
        public GameInitialization(UpdateController update)
        {
            var input = new InputController();

            update.Add(input);
        }
    }
}