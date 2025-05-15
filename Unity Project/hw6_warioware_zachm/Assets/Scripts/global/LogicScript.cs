using UnityEngine;

namespace global
{
    public class LogicScript : MonoBehaviour
    {
        public static float Speed = 1f;
        public static bool Win;

        public void Awake()
        {
            Win = false;
        }
        
        public void ChangeSpeed(float newSpeed)
        {
            Speed = newSpeed;
        }

        
    }
}
