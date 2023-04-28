using Raylib_cs;
using static Raylib_cs.Raylib;

using CopperStudios.Tools;
using CopperStudios.UI;
using System.Diagnostics;
using System.Numerics;

namespace CopperStudios.Engine 
{

public static class Program
{
    // Window Settings
    private static Vector2Int DefaultWindowSize = new Vector2Int(800, 480);
    private static Vector2Int MinimumWindowSize = new Vector2Int(640, 480);
    private static string DefaultWindowTitle = "CopperStudios.Engine3D";

    public static Action? actionTest;

    // Engine Actions
    public static bool engineStartCalled = false;
    public static Action? EngineStart;
    public static Action? EngineUpdate;
    public static Action? EngineUIUpdate;
    public static Action? EngineDrawUpdate;
    public static Action? EngineEnd;

    // Game Actions
    public static bool gameStartCalled = false;
    public static Action? GameStart;
    public static Action? GameUpdate;
    public static Action? GameUIUpdate;
    public static Action? GameDrawUpdate;
    public static Action? GameEnd;

    // Game
    public static int targetFPS = 75;
    public static Stopwatch gameTime = new Stopwatch();
    public static Camera3D camera = new Camera3D();
    public static List<GameObject> gameObjects = new List<GameObject>();

    public static void Main()
    {
        // Start Process
        StartEngine();
        StartGame();
        
        if(EngineStart != null)
            EngineStart?.Invoke();

        engineStartCalled = true;

        if(GameStart != null)
            GameStart.Invoke();

        gameStartCalled = true;

        // The UI Engine is started after everything else so gameobjects can register their own panels
        DebugEngine.Log("Starting UI Engine");
        UIEngine.StartUI();
        DebugEngine.Log("UI Engine Started");


        // Update loop
        while (!WindowShouldClose())
        {
            // Game and interal updates
            if(EngineUpdate != null)
                EngineUpdate?.Invoke();

            if(GameUpdate != null)
                GameUpdate.Invoke();
            
            // Starts drawing the game 
            BeginDrawing();
            ClearBackground(Color.WHITE);

            BeginMode3D(camera);
            
            // Game and internal draw updates
            if(EngineDrawUpdate != null)
                EngineDrawUpdate?.Invoke();

            if(GameDrawUpdate != null)
                GameDrawUpdate.Invoke();

            // Stops drawing 3D 
            // This is called before UI update so UI isn't rendered world space
            EndMode3D();

            // Game and Internal ui updates
            UIEngine.Update();
            
            if(EngineUIUpdate != null)
                EngineUIUpdate?.Invoke();
                
            if(GameUIUpdate != null)
                GameUIUpdate.Invoke();

            // Fully stops drawing
            EndDrawing();
        }

        // Game and Internal stop processes
        if(EngineEnd != null)
            EngineEnd?.Invoke();
            
        if(GameEnd != null)
            GameEnd.Invoke();

        StopGame();
        StopEngine();
    }

    #region Game

    private static void StartGame()
    {
        try
        {
            gameTime.Start();

            DebugEngine.LogImportant("Starting Game");  

            EngineStart += Game.Start;
            EngineUpdate += Game.Update;
            EngineUIUpdate += Game.UIUpdate;
            EngineDrawUpdate += Game.DrawUpdate;
            EngineEnd += Game.End;

            DebugEngine.Log("Creating game camera");

            camera = new Camera3D();
            camera.position = new Vector3(0, 10, 10);
            camera.target = new Vector3(0, 0, 0);    
            camera.up = new Vector3(0.0f, 1.0f, 0.0f);
            camera.fovy = 45.0f;
            camera.projection = CameraProjection.CAMERA_PERSPECTIVE;
            
        }
        catch (System.Exception ex)
        {
            DebugEngine.LogError("Game has failed to start");
            DebugEngine.LogError($"Error - {ex}");
            Environment.Exit(0);
        }
    }

    private static void StopGame()
    {   
        try
        {
            gameTime.Stop();
            DebugEngine.LogImportant($"Game played for {gameTime.Elapsed.ToString(@"m\:ss\.fff")}");
            DebugEngine.LogImportant("Stopping Game");

            EngineStart -= Game.Start;
            EngineUpdate -= Game.Update;
            EngineUIUpdate -= Game.UIUpdate;
            EngineDrawUpdate -= Game.DrawUpdate;
            EngineEnd -= Game.End;
        }
        catch (System.Exception ex)
        {
            DebugEngine.LogError("Game has failed to start");
            DebugEngine.LogError($"Error - {ex}");
            Environment.Exit(0);
        }
    
    }

    public static void RegisterGameObject(GameObject gameObject)
    {
        DebugEngine.Log($"Registerd new game object - '{gameObject.name}'");
        Program.gameObjects.Add(gameObject);
        gameObject.InitiateGameObject();
    }

    public static void RegisterUIPanel(UIPanel panel)
    {
        DebugEngine.Log($"Registerd new UI Panel - '{panel.name}'");
        UIEngine.AddPanel(panel);
    }

    public static void DeRegisterGameObject(GameObject gameObject)
    {
        gameObjects.Remove(gameObject);
        gameObjects.RemoveAll(item => item == null);
    }

    #endregion

    #region Engine

    private static void StartEngine()
    {
        try
        {
            DebugEngine.LogImportant("Starting Engine");
            var timer = new Stopwatch();
            timer.Start();

            DebugEngine.Log("Settings Target FPS");
            Raylib.SetTargetFPS(targetFPS);

            DebugEngine.Log("Set Raylib Flags");
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.SetTraceLogLevel(TraceLogLevel.LOG_FATAL);

            DebugEngine.Log("Starting Raylib Engine");

            DebugEngine.Log($"Starting Raylib Window with a size of {DefaultWindowSize.X} by {DefaultWindowSize.Y}");
            DebugEngine.Log($"Starting Raylib Window with title of {DefaultWindowTitle}");

            Raylib.InitWindow(DefaultWindowSize.X, DefaultWindowSize.Y, DefaultWindowTitle);
            Raylib.SetWindowMinSize(MinimumWindowSize.X, MinimumWindowSize.Y);
            DebugEngine.Log("Raylib Engine Started");

            DebugEngine.Log("Starting Sound Engine");
            SoundEngine.StartAudio();
            DebugEngine.Log("Sound Engine Started");

            DebugEngine.Log("Starting Debug Engine");
            DebugEngine.StartDebugEngine();
            DebugEngine.Log("Loading Debug Panels");
            DebugEngine.LoadDebugPanels(new InfoPanel());
            DebugEngine.Log("Debug Engine Started");

        
            DebugEngine.Log("Starting Model Engine");
            ModelEngine.StartEngine();
            DebugEngine.Log("Model Engine Started");

            timer.Stop();
            DebugEngine.LogImportant($"Started Engine in {timer.Elapsed.ToString(@"m\:ss\.fff")}");   
        }
        catch (System.Exception ex)
        {
            DebugEngine.LogError("Engine has failed to start");
            DebugEngine.LogError($"Error - {ex}");
            Environment.Exit(0);
        }
    }

    private static void StopEngine()
    {
        try
        {
            UIEngine.StopUI();
            DebugEngine.Log("Stopped UI Engine");

            SoundEngine.StopAudio();
            DebugEngine.Log("Stopped Audio Engine");

            DebugEngine.StopDebugEngine();
            DebugEngine.Log("Stopped Debug Engine");

            ModelEngine.StopEngine();
            DebugEngine.Log("Stopped Model Engine");

            CloseWindow();
            DebugEngine.Log("Closed Window");
        }
        catch (System.Exception ex)
        {
            DebugEngine.LogError("Engine has failed to stop");
            DebugEngine.LogError($"Error - {ex}");
            Environment.Exit(0);
        }
    }

    #endregion
}

}