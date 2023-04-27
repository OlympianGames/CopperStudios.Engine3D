using System.Numerics;

namespace CopperStudios.Tools
{
    public static class Vector3IntExtensions
    {
        public static Vector3Int WithX(this Vector3Int v, int value)
        {
            return new Vector3Int(value, v.Y, v.Z);
        }

        public static Vector3Int WithY(this Vector3Int v, int value)
        {
            return new Vector3Int(v.X, value, v.Z);
        }

        public static Vector3Int WithZ(this Vector3Int v, int value)
        {
            return new Vector3Int(v.X, v.Z, value);
        }
    }
}