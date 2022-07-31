using System;
using UnityEngine;

namespace StayFast
{
    [Serializable]
    public class SoundDescript
    {
        [SerializeField] public string clip;
        [SerializeField] public ClipType type;
    }
}