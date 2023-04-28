using CopperStudios.Tools;
using CopperStudios.Engine;
using static CopperStudios.Engine.Program;

using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/// <summary> Program class for game oriented functions </summary>
public static class Game
{
    public static int gridSlices = 100;
    public static float gridSpacing = 1;
    public static CameraController cameraController = new CameraController();

    /// <summary> Called once at the start of the game</summary>
    public static void Start()
    {
        RegisterGameObject(cameraController);
        // RegisterGameObject(new SineCubes());
        // RegisterGameObject(new PerlinCubes());

        // ModelEngine.LoadModel("Game/Resources/Models/bevel_cube.obj", "Bevel Cube");

    }
   
    
    /// <summary> First update called, used for changing values </summary>
    public static void Update()
    {

    }



    /// <summary> Second update called, used for rendering UI </summary>
    public static void UIUpdate()
    {
        
    }

    /// <summary> Third update called, used for rendering game objects</summary>
    public static void DrawUpdate()
    {
        DrawGrid(gridSlices, gridSpacing);
    }

    /// <summary> Called once at the end of the game </summary>
    public static void End()
    {
        
    }
}
