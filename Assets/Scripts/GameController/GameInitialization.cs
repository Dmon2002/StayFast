using UnityEngine;
using UnityEngine.UI;

namespace StayFast
{
    public class GameInitialization
    {
        private GameObject empty = new GameObject("For components");
        
        public GameInitialization(UpdateController update, AllDescriptions descriptions, Transform canvas, Button button)
        {
            var input = new InputController();
            var instantiate = empty.AddComponent<MonoFactory>();
            var coroutine = empty.AddComponent<CoroutineSystem>();
            var stateController = new StateController(input, descriptions, canvas, coroutine, instantiate);

            var menuFactory = new MenuFactory(instantiate, canvas);
            var view = menuFactory.CreateMenu();
            var menu = new MenuController(view, input, instantiate, descriptions.SoundLocator);
            button.onClick.AddListener(menu.OnClickPaused);

            update.Add(input);

        }

        public void Ghghghgf()
        {
            
        }
    }
}