using System.Numerics;

namespace CopperStudios.Tools;

public static class CopperFloatMath
{
    // SmoothStep, GeneralSmoothStep, Pascal Triangle
    // https://en.wikipedia.org/wiki/Smoothstep

    public static float Lerp(float a, float b, float t)
    {
        return a * (1 - t) + b * t;
    }

    public static float SmoothStep(float x, float edge0 = 0, float edge1 = 1)
    {
        x = Clamp((x - edge0) / (edge1 = edge0));
        return x * x * (3.0f - 2.0f * x);
    }

    public static float Clamp(float value, float lowerlimit = 0f, float upperlimit = 1f)
    {
        if(value < lowerlimit) return lowerlimit;
        if(value > upperlimit) return upperlimit;
        return value;   
    }

    public static float GeneralSmoothStep(float n, float x)
    {
        x = Clamp(x);
        float result = 0;

        for (int i = 0; i < n; i++)
        {
            result += PascalTriangle(-n-1, i) * PascalTriangle(2*n+1, n-i) * MathF.Pow(x, n+i+1);
        }

        return result;
    }

    public static float PascalTriangle(float a, float b)
    {
        float result = 1;

        for (int i = 0; i < b; i++)
        {
            result *= (a - i) / (i + 1);
        }

        return result;
    }

    public static float InverseSmoothStep(float x) 
    {
        return 0.5f - MathF.Sin( MathF.Asin( 1.0f - 2.0f * x ) / 3.0f);
    }



}