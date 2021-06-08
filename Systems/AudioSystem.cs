using System.Collections.Generic;
using SFML.Audio;

namespace Asteroids.Systems{
    public static class AudioSystem {
        static List<Sound> sounds=new List<Sound>();

        public static void PlaySound(string name){
            Sound sound=new Sound(AssetManager.GetSound(name));
            sound.Play();
            sounds.Add(sound);
        }
    }
}