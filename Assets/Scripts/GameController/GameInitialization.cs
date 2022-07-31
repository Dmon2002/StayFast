using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace StayFast
{
    public class GameInitialization
    {
        private GameObject empty = new GameObject("For components");
        
        public GameInitialization(UpdateController update, AllDescriptions descriptions, Transform canvas)
        {
            var input = new InputController();
            var instantiate = empty.AddComponent<MonoFactory>();
            var coroutine = empty.AddComponent<CoroutineSystem>();
            var stateController = new StateController(input, descriptions, canvas, coroutine, instantiate);

            var menuFactory = new MenuFactory(instantiate, canvas);
            var view = menuFactory.CreateMenu();
            var menu = new MenuController(view, input, instantiate);

            update.Add(input);

        }

        public void Ghghghgf()
        {
            
        }
    }
}