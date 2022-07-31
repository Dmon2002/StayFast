using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StayFast
{
    public class SoundLocator : MonoBehaviour
    {
        [SerializeField] private SoundDescript[] allSound;

        private Dictionary<ClipType, AudioSource> audioDictionary = new Dictionary<ClipType, AudioSource>();

        public void Init()
        {
            foreach (var sound in allSound)
            {
                var source = Loader.Load<AudioSource>(sound.clip);
                audioDictionary.Add(sound.type, source);
            }
        }

        public void PlayAudio(ClipType type)
        {
            var sound = audioDictionary[type];
            sound.enabled = true;
            sound.Play();
        }

        public void StopAudio(ClipType type)
        {
            var sound = audioDictionary[type];
            sound.enabled = false;
            sound.Stop();
        }


    }
}