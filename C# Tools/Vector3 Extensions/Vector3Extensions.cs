using System.Numerics;

namespace CopperStudios.Tools
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 v, float value)
        {
            return new Vector3(value, v.Y, v.Z);
        }

        public static Vector3 WithY(this Vector3 v, float value)
        {
            return new Vector3(v.X, value, v.Z);
        }

        public static Vector3 WithZ(this Vector3 v, float value)
        {
            return new Vector3(v.X, v.Z, value);
        }
    }
}