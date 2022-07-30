using UnityEngine;

namespace StayFast
{
    public interface IDaysConfigs : IConfig
    {
        Sprite TubeSprite { get; }
        Sprite MassageSprite { get; }
        
    }

    public interface IConfig
    {
        
    }
}