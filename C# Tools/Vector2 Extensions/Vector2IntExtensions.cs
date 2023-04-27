using System.Numerics;

namespace CopperStudios.Tools
{
    public static class Vector2IntExtensions
    {
        public static Vector2Int WithY(this Vector2Int v, int value)
        {
            return new Vector2Int(v.X, value);
        }

        public static Vector2Int WithX(this Vector2Int v, int value)
        {
            return new Vector2Int(value, v.Y);
        }
    }
}