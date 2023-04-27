using static Raylib_cs.Raylib;

namespace CopperStudios.Engine
{

/// <summary> Engine for Time</summary>
public static class TimeEngine
{
    /// <summary> Total time the game has been running </summary>
    public static float time
    {
        get => (float) GetTime();
    }

    /// <summary> Time since the last frame </summary>
    public static float deltaTime
    {
        get => GetFrameTime();
    }
}

}