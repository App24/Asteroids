using System;
using SFML.System;

namespace Asteroids.Systems{
    public static class Maths {
        public static float Lerp(float a, float b, float f){
            return a + f * (b-a);
        }

        public static double ToRadians(double degrees){
            return (Math.PI/180f)*degrees;
        }

        public static double Distance(this Vector2f origin, Vector2f position){
            Vector2f dif=origin-position;
            float total=0;
            total+=(dif.X*dif.X);
            total+=(dif.Y*dif.Y);
            return Math.Sqrt(total);
        }
    }
}