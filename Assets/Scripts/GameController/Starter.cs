using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class Starter : MonoBehaviour
    {
        private GameInitialization _initialization;
        private UpdateController _update;
    
        private void Start()
        {
            _update = new UpdateController();
            var initialization = new GameInitialization(_update);
        }

    
        void Update()
        {
        
        }
    }
}

