using System.Numerics;

namespace CopperStudios.Tools;

public static class CopperVector3Math
{
    public static Vector3 Lerp(this Vector3 vector, Vector3 targetVector, float t)
    {
        Vector3 newVector = new Vector3();
        newVector.X = CopperFloatMath.Lerp(newVector.X, targetVector.X, t);
        newVector.Y = CopperFloatMath.Lerp(newVector.Y, targetVector.Y, t);
        newVector.Z = CopperFloatMath.Lerp(newVector.Z, targetVector.Z, t);
        return newVector;
    }
}