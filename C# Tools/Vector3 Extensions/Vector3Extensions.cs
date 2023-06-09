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

        public static float Magnitude(this Vector3 v)
        {
            // https://docs.unity3d.com/ScriptReference/Vector3-magnitude.html
            return MathF.Sqrt( ( v.X * v.X + v.Y * v.Y + v.Z * v.Z) );
        }

        public static Vector3 ToVector3(this SerializedVector3 serializedVector3)
        {
            return new Vector3(serializedVector3.x, serializedVector3.y, serializedVector3.z);
        }

        public static SerializedVector3 FromVector3(this Vector3 vector3)
        {
            return new SerializedVector3(vector3);
        }
    }
}