using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private AllDescriptions _descriptions;
        [SerializeField] private Transform _canvas;
        private GameInitialization _initialization;
        private UpdateController _update;
    
        private void Start()
        {
            _update = new UpdateController();
            var initialization = new GameInitialization(_update, _descriptions, _canvas);
        }

    
        private void Update()
        {
            _update.Execute(Time.deltaTime);
        }
    }
}

