using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using Asteroids.Systems;
using Asteroids.Input;

namespace Asteroids{
    public class Player : Sprite {
        public float inertia;
        public float velocity;
        
        const float MAX_ROT=120;
        const float MAX_VEL=120;

        public int points=0;

        public bool dead;

        public Player(){
            Texture=AssetManager.GetTexture("player");
            Origin=new Vector2f(Texture.Size.X*0.5f, Texture.Size.Y*0.5f);
            Position=new Vector2f(DisplayManager.Width/2f, DisplayManager.Height/2f);
        }

        public void Update(){
            if(KeyboardInput.IsKeyHeld(Keyboard.Key.D)){
                inertia=MAX_ROT;
            }else if(KeyboardInput.IsKeyHeld(Keyboard.Key.A)){
                inertia=-MAX_ROT;
            }else{
                inertia=Maths.Lerp(0, inertia, 1-(Delta.DeltaTime*5f));
            }

            if(KeyboardInput.IsKeyHeld(Keyboard.Key.W)){
                velocity=MAX_VEL;
            }else if(KeyboardInput.IsKeyHeld(Keyboard.Key.S)){
                velocity=-MAX_VEL;
            }else{
                velocity=Maths.Lerp(0, velocity, 1-(Delta.DeltaTime*3f));
            }

            if(inertia!=0f){
                Rotation+=inertia*Delta.DeltaTime;
            }

            if(velocity!=0f){
                float hor=(float) Math.Sin(Maths.ToRadians(Rotation))*velocity*Delta.DeltaTime;
                float ver=-((float) Math.Cos(Maths.ToRadians(Rotation))*velocity*Delta.DeltaTime);

                Position+=new Vector2f(hor, ver);

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

            if(KeyboardInput.IsKeyPressed(Keyboard.Key.Space)){
                float spawnHor=(float) Math.Sin(Maths.ToRadians(Rotation))*(Texture.Size.X/2f);
                float spawnVer=-((float) Math.Cos(Maths.ToRadians(Rotation))*(Texture.Size.Y/2f));
                Bullet.SpawnBullet(Position+new Vector2f(spawnHor, spawnVer), Rotation);
            }
        }

        
    }
}