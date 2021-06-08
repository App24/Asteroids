using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using Asteroids.Systems;
using Asteroids.Input;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayManager.InitializeDisplay(600, 600, "Asteroids");

            AssetLoader.LoadAssets();

            Player player=new Player();

            for(int i=0;i<5;i++){
                Asteroid.SpawnAsteroid();
            }

            Clock spawnClock=new Clock();

            Text text=new Text("0", AssetManager.GetFont("arial"), 20);
            text.OutlineColor=Color.Black;
            text.OutlineThickness=2;

            while(DisplayManager.Window.IsOpen){
                Delta.UpdateDeltaTime();
                DisplayManager.Window.DispatchEvents();

                if(!player.dead)
                    player.Update();

                if(spawnClock.ElapsedTime.AsSeconds()>=5){
                    spawnClock.Restart();
                    Asteroid.SpawnAsteroid();
                }

                foreach(Bullet bullet in Bullet.bullets){
                    bullet.Update();
                    foreach(Asteroid asteroid in Asteroid.asteroids){
                        if(bullet.GetGlobalBounds().Intersects(asteroid.GetGlobalBounds())){
                            asteroid.Split();
                            bullet.Remove();
                            player.points++;
                            text.DisplayedString=player.points.ToString();
                            break;
                        }
                    }
                }

                foreach(Asteroid asteroid in Asteroid.asteroids){
                    asteroid.Update();
                    if(asteroid.GetGlobalBounds().Intersects(player.GetGlobalBounds())){
                        // player.dead=true;
                    }
                }

                DisplayManager.Window.Clear();
                if(!player.dead)
                    DisplayManager.Window.Draw(player);

                foreach(Bullet bullet in Bullet.bullets){
                    DisplayManager.Window.Draw(bullet);
                }

                foreach(Asteroid asteroid in Asteroid.asteroids){
                    DisplayManager.Window.Draw(asteroid);
                }

                DisplayManager.Window.Draw(text);

                Bullet.RemoveBullets();
                Asteroid.RemoveAsteroids();

                DisplayManager.Window.Display();

                KeyboardInput.ResetKeyboard();
            }
        }
    }
}
