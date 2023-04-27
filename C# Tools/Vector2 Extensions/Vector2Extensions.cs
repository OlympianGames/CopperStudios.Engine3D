using System.Numerics;

namespace CopperStudios.Tools
{
    public static class Vector2Extensions
    {
        public static Vector2 WithX(this Vector2 v, float value)
        {
            return new Vector2(value, v.Y);
        }
        
        public static Vector2 WithY(this Vector2 v, float value)
        {
            return new Vector2(v.X, value);
        }
    }
}