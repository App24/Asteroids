using SFML.System;

namespace Asteroids.Systems{
    public static class Delta{
        public static float DeltaTime{get;private set;}

        static Clock clock=new Clock();

        public static void UpdateDeltaTime(){
            DeltaTime=clock.Restart().AsSeconds();
        }
    }
}