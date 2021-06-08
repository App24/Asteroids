using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Audio;

namespace Asteroids.Systems{
    public static class AssetManager {
        static Dictionary<string, Texture> textures=new Dictionary<string, Texture>();
        static Dictionary<string, Font> fonts=new Dictionary<string, Font>();
        static Dictionary<string, SoundBuffer> buffers=new Dictionary<string, SoundBuffer>();

        public static void LoadTexture(string name, string path){
            try{
                Texture texture=new Texture(path);
                texture.Smooth=true;
                textures.Add(name, texture);
            }catch(SFML.LoadingFailedException){
                Console.WriteLine($"Couldn't load Texture {name}. Path {path}");
            }
        }

        public static void LoadFont(string name, string path){
            try{
                Font font=new Font(path);
                fonts.Add(name, font);
            }catch(SFML.LoadingFailedException){
                Console.WriteLine($"Couldn't load Font {name}. Path {path}");
            }
        }

        public static void LoadSound(string name, string path){
            try{
                SoundBuffer buffer=new SoundBuffer(path);
                buffers.Add(name, buffer);
            }catch(SFML.LoadingFailedException){
                Console.WriteLine($"Couldn't load Sound {name}. Path {path}");
            }
        }

        public static Texture GetTexture(string name){
            if(!textures.TryGetValue(name, out Texture texture)){
                return null;
            }
            return texture;
        }

        public static Font GetFont(string name){
            if(!fonts.TryGetValue(name, out Font font)){
                return null;
            }
            return font;
        }

        public static SoundBuffer GetSound(string name){
            if(!buffers.TryGetValue(name, out SoundBuffer buffer)){
                return null;
            }
            return buffer;
        }
    }
}