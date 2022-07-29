using UnityEngine;

namespace StayFast
{
    public class GameInitialization
    {
        public GameInitialization(UpdateController update, AllDescriptions descriptions, Transform canvas)
        {
            var input = new InputController();
            var stateController = new StateController(input, descriptions);
            var instantiate = new GameObject().AddComponent<MonoFactory>();

            var go = Loader.Load<GameObject>("Prefabs/UI/PauseMenu");
            var instant = instantiate.Instant(go, canvas);
            var view = instant.GetComponent<MenuView>();
            var menu = new MenuController(view, input, instantiate);

            update.Add(input);
        }
    }
}