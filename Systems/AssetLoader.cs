namespace Asteroids.Systems{
    public static class AssetLoader {
        public static void LoadAssets(){
            AssetManager.LoadTexture("player", "Assets/player.png");
            AssetManager.LoadTexture("asteroid", "Assets/asteroid.png");

            AssetManager.LoadFont("arial", "Assets/arial.ttf");

            AssetManager.LoadSound("shoot", "Assets/shoot.wav");
            AssetManager.LoadSound("hit", "Assets/hit.wav");
        }
    }
}