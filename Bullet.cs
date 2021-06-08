using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Asteroids.Systems;

namespace Asteroids{
    public class Bullet : CircleShape {
        Vector2f spawnPosition;
        Vector2f distanceTravelled;

        public static List<Bullet> bullets=new List<Bullet>();
        static List<Bullet> toRemove=new List<Bullet>();

        const int MAX_BULLETS=8;
        
        const float MAX_SPEED=300;

        public Bullet(Vector2f position){
            FillColor=Color.White;
            Radius=5;
            Origin=new Vector2f(Radius/2f, Radius/2f);
            Position=position;
            spawnPosition=position;
            distanceTravelled=position;
        }

        public new void Update(){
            base.Update();

            float hor=(float) Math.Sin(Maths.ToRadians(Rotation))*MAX_SPEED*Delta.DeltaTime;
            float ver=-((float) Math.Cos(Maths.ToRadians(Rotation))*MAX_SPEED*Delta.DeltaTime);
            Position+=new Vector2f(hor, ver);
            distanceTravelled+=new Vector2f(hor, ver);

            // if(distanceTravelled.Distance(spawnPosition)>=1000){
            //     Remove();
            // }

            if((Position.X<-Radius/2f)||(Position.X>=DisplayManager.Width+Radius/2f)||(Position.Y<-Radius/2f)||(Position.Y>=DisplayManager.Height+Radius/2f)){
                Remove();
            }

            // if(Position.X<-Radius/2f){
            //     Position=new Vector2f(DisplayManager.Width+Radius/2f, Position.Y);
            // }else if(Position.X>=DisplayManager.Width+Radius/2f){
            //     Position=new Vector2f(-Radius/2f, Position.Y);
            // }

            // if(Position.Y<-Radius/2f){
            //     Position=new Vector2f(Position.X, DisplayManager.Height+Radius/2f);
            // }else if(Position.Y>=DisplayManager.Height+Radius/2f){
            //     Position=new Vector2f(Position.X, -Radius/2f);
            // }
        }

        public void Remove(){
            toRemove.Add(this);
        }

        public static void RemoveBullets(){
            foreach(Bullet bullet in toRemove) bullets.Remove(bullet);
            toRemove.Clear();
        }

        public static void SpawnBullet(Vector2f position, float rotation){
            if(bullets.Count>=MAX_BULLETS){
                return;
            }
            AudioSystem.PlaySound("shoot");
            Bullet bullet=new Bullet(position);
            bullet.Rotation=rotation;
            bullets.Add(bullet);
        }
    }
}