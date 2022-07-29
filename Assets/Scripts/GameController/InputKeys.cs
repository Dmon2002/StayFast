using System;
using UnityEngine;

namespace StayFast
{
    public class InputKeys
    {
        public void GetMouseLeft(Action action)
        {
            if(Input.GetMouseButton(0)) action?.Invoke();
        }

        public void GetESC(Action action)
        {
            if(Input.GetKeyDown(KeyCode.Escape)) action?.Invoke(); 
        }
    }
}