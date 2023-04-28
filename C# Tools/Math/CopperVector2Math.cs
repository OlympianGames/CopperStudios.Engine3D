using System.Numerics;

namespace CopperStudios.Tools;

public static class CopperVector2Math
{
    public static Vector2 Lerp(this Vector2 vector, Vector2 targetVector, float t)
    {
        Vector2 newVector = new Vector2();
        newVector.X = CopperFloatMath.Lerp(newVector.X, targetVector.X, t);
        newVector.Y = CopperFloatMath.Lerp(newVector.Y, targetVector.Y, t);
        return newVector;
    }
}