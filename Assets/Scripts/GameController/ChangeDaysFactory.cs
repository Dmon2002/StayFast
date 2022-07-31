namespace StayFast
{
    public class ChangeDaysFactory
    {
        private AllDescriptions description;
        private MonoFactory instantiate;
        private InputController input;
        private CoroutineSystem _coroutine;
        private ProfilePlayer _profile;

        public ChangeDaysFactory(AllDescriptions description, MonoFactory instantiate, 
            InputController input, CoroutineSystem coroutine, ProfilePlayer profile)
        {
            this.description = description;
            this.instantiate = instantiate;
            this.input = input;
            _coroutine = coroutine;
            _profile = profile;
        }

        public ChangeDaysController CreateController()
        {
            var nightView = description.NightConfig.NightView;
            var tube = description.NightConfig.TubeSprite;
            var massage = description.NightConfig.MessageView;
            var result = new ChangeDaysController(nightView, tube, massage, input, _coroutine, _profile);

            return result;
        }
    }
}