using SFML.Window;

namespace Asteroids.Input{
    public static class KeyboardInput{
        
        static bool[] keysHeld=new bool[(int)Keyboard.Key.KeyCount];
        static bool[] keysPressed = new bool[(int)Keyboard.Key.KeyCount];
        static bool[] keysPressedThisFrame = new bool[(int)Keyboard.Key.KeyCount];

        static bool altHeld, shiftHeld, ctrlHeld;

        public static bool IsKeyHeld(Keyboard.Key key){
            return keysHeld[(int)key];
        }

        public static bool IsKeyPressed(Keyboard.Key key)
        {
            if(keysPressedThisFrame[(int)key])
                return true;
            if (keysHeld[(int)key] && !keysPressed[(int)key])
            {
                keysPressed[(int)key] = true;
                keysPressedThisFrame[(int)key]=true;
                return true;
            }else if (!keysHeld[(int)key])
            {
                keysPressed[(int)key] = false;
            }
            return false;
        }

        public static bool IsAltHeld(){
            return altHeld;
        }

        public static bool IsControlHeld(){
            return ctrlHeld;
        }

        public static bool IsShiftHeld(){
            return shiftHeld;
        }

        public static void ResetKeyboard(){
            for (int i = 0; i < keysPressedThisFrame.Length; i++)
            {
                keysPressedThisFrame[i]=false;
            }
        }

        #region Events
        public static void KeyPressed(object sender, KeyEventArgs e){
            if((int)e.Code<0||(int)e.Code>(int)Keyboard.Key.KeyCount)
                return;
            keysHeld[(int)e.Code]=true;
            altHeld=e.Alt;
            ctrlHeld=e.Control;
            shiftHeld=e.Shift;
        }

        public static void KeyReleased(object sender, KeyEventArgs e){
            if((int)e.Code<0||(int)e.Code>(int)Keyboard.Key.KeyCount)
                return;
            keysHeld[(int)e.Code]=false;
            altHeld=e.Alt;
            ctrlHeld=e.Control;
            shiftHeld=e.Shift;
        }
        #endregion
    }
}