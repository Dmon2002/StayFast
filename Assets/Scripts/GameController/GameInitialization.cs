using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class GameInitialization
    {
        public GameInitialization(UpdateController update, AllDescriptions descriptions, Transform canvas)
        {
            var input = new InputController();
            var instantiate = new GameObject().AddComponent<MonoFactory>();
            var stateController = new StateController(input, descriptions);

            var menuFactory = new MenuFactory(instantiate, canvas);
            var view = menuFactory.CreateMenu();
            var menu = new MenuController(view, input, instantiate);

            update.Add(input);
        }
    }
}