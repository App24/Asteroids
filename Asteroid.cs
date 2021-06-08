using System;
using SFML.Graphics;
using SFML.System;
using SFML.Audio;
using Asteroids.Systems;
using System.Collections.Generic;

namespace Asteroids{
    public class Asteroid : Sprite {
        public float Speed;
        public float MoveRotation;
        public float RotationRotation;
        int type;
        
        public static List<Asteroid> asteroids=new List<Asteroid>();
        static List<Asteroid> toRemove=new List<Asteroid>();

        public Asteroid(int type=0){
            Texture=AssetManager.GetTexture($"asteroid");
            Scale=new Vector2f(1/(1f+type), 1/(1f+type));
            Origin=new Vector2f(Texture.Size.X*0.5f, Texture.Size.Y*0.5f);
            this.type=type;
            Random rand=new Random();
            int axis=rand.Next(5);
            switch(axis){
                case 0:{
                    int pos=rand.Next((int)DisplayManager.Width);
                    Position=new Vector2f(pos, 0);
                }break;
                case 1:{
                    int pos=rand.Next((int)DisplayManager.Height);
                    Position=new Vector2f(0, pos);
                }break;
                case 3:{
                    int pos=rand.Next((int)DisplayManager.Width);
                    Position=new Vector2f(pos, DisplayManager.Height);
                }break;
                case 4:{
                    int pos=rand.Next((int)DisplayManager.Height);
                    Position=new Vector2f(DisplayManager.Width, pos);
                }break;
            }
            MoveRotation=rand.Next(360);
            RotationRotation=rand.Next(45, 180);
            Speed=rand.Next(30, 80);
        }

        public void Update(){
            float hor=(float) Math.Sin(Maths.ToRadians(MoveRotation))*Speed*Delta.DeltaTime;
            float ver=-((float) Math.Cos(Maths.ToRadians(MoveRotation))*Speed*Delta.DeltaTime);
            Position+=new Vector2f(hor,ver);
            Rotation+=RotationRotation*Delta.DeltaTime;

            if(Position.X<-Texture.Size.X/2f){
                Position=new Vector2f(DisplayManager.Width+Texture.Size.X/2f, Position.Y);
            }else if(Position.X>=DisplayManager.Width+Texture.Size.X/2f){
                Position=new Vector2f(-Texture.Size.X/2f, Position.Y);
            }

            if(Position.Y<-Texture.Size.Y/2f){
                Position=new Vector2f(Position.X, DisplayManager.Height+Texture.Size.Y/2f);
            }else if(Position.Y>=DisplayManager.Height+Texture.Size.Y/2f){
                Position=new Vector2f(Position.X, -Texture.Size.Y/2f);
            }
        }

        public static Asteroid SpawnAsteroid(int type=0){
            Asteroid asteroid=new Asteroid(type);
            asteroids.Add(asteroid);
            return asteroid;
        }

        public void Split(){
            AudioSystem.PlaySound("hit");

            if(type==1){
                Remove();
                return;
            }
            Asteroid asteroid1=SpawnAsteroid(type+1);
            asteroid1.Position=Position;
            asteroid1.RotationRotation=RotationRotation*2f;
            asteroid1.Speed=Speed*1.5f;
            asteroid1.MoveRotation=MoveRotation;

            Asteroid asteroid2=SpawnAsteroid(type+1);
            asteroid2.Position=Position;
            asteroid2.RotationRotation=RotationRotation*2f;
            asteroid2.Speed=Speed*1.5f;
            asteroid2.MoveRotation=360-MoveRotation;
            Remove();
        }

        public void Remove(){
            toRemove.Add(this);
        }

        public static void RemoveAsteroids(){
            foreach(Asteroid asteroid in toRemove) asteroids.Remove(asteroid);
            toRemove.Clear();
        }
    }
}