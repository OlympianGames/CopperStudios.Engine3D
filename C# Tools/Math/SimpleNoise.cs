using System;

namespace CopperStudios.Tools;
using static CopperStudios.Tools.CopperFloatMath;

public class SimpleNoise
{
    private int seed;

    public SimpleNoise(int seed)
    {
        this.seed = seed;
    }

    public void SetSeed(int seed)
    {
        this.seed = seed;
    }

    public float Generate(float x, float z, float scale = 1)
    {
        int xInt = (int)x;
        int zInt = (int)z;

        xInt *= (int)scale;
        zInt *= (int)scale;

        float corner1 = SmoothedNoise(xInt, zInt);
        float corner2 = SmoothedNoise(xInt + 1, zInt);
        float corner3 = SmoothedNoise(xInt, zInt + 1);
        float corner4 = SmoothedNoise(xInt + 1, zInt + 1);

        float fracX = x - xInt;
        float fracZ = z - zInt;

        float lerp1 = Lerp(corner1, corner2, fracX);
        float lerp2 = Lerp(corner3, corner4, fracX);

        float lerp3 = Lerp(lerp1, lerp2, fracZ);

        return lerp3;
    }

    private float SmoothedNoise(int x, int z)
    {
        float corners = (Noise(x - 1, z - 1) + Noise(x + 1, z - 1) + Noise(x - 1, z + 1) + Noise(x + 1, z + 1)) / 16f;
        float sides = (Noise(x - 1, z) + Noise(x + 1, z) + Noise(x, z - 1) + Noise(x, z + 1)) / 8f;
        float center = Noise(x, z) / 4f;

        return corners + sides + center;
    }

    private float Noise(int x, int z)
    {
        int n = x + z * 57 + seed;
        n = (n << 13) ^ n;
        return (1f - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824f);
    }
}
