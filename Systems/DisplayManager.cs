using System;
using Asteroids.Input;
using SFML.Graphics;
using SFML.Window;

namespace Asteroids.Systems{
    public static class DisplayManager {
        public static RenderWindow Window{get;private set;}

        public static uint Width{get{return Window.Size.X;}}
        public static uint Height{get{return Window.Size.Y;}}

        public static void InitializeDisplay(uint width, uint height, string title){
            ContextSettings settings=new ContextSettings();
            settings.AntialiasingLevel=8;
            Window=new RenderWindow(new VideoMode(width, height), title, Styles.Close|Styles.Titlebar, settings);
            Window.Closed+=new EventHandler((_,__)=>{Close();});
            Window.KeyPressed+=KeyboardInput.KeyPressed;
            Window.KeyReleased+=KeyboardInput.KeyReleased;
            Window.SetVerticalSyncEnabled(true);
        }

        public static void Close(){
            Window.Close();
        }
    }
}