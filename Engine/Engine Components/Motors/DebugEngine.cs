using CopperStudios.UI;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CopperStudios.Engine
{

/// <summary> Internal engine for debugging </summary>
public static class DebugEngine
{   
    // Logs Settings
    /// <summary> Show logs in the console</summary>
    public static bool ShowLogs = true;
    /// <summary> Show error logs in the console</summary>
    public static bool ShowErrorsLogs = true;
    /// <summary> Show warning logs in the console</summary>
    public static bool ShowWarningLogs = true;
    /// <summary> Show important logs in the console</summary>
    public static bool ShowImportantLogs = true;

    // Debug Panels
    /// <summary> List of debug panels for toggling with a keybind</summary>
    private static List<Panel> DebugPanels = new List<Panel>();
    /// <summary> Current state of debug panels </summary>    
    private static bool DebugPanelsState;

    #region Engine Internal
    /// <summary> Starting the debug engine </summary>
    public static void StartDebugEngine()
    {
        DebugEngine.Log("Connecting Update Action");
        Program.EngineUpdate += DebugEngineUpdate;
    }

    /// <summary> Stopping the debug engine </summary>
    public static void StopDebugEngine()
    {
        DebugEngine.Log("Disconnecting Update Action");
        Program.EngineUpdate -= DebugEngineUpdate;

        WriteLogs();
    }

    /// <summary> Internal update function for the debug engine </summary>
    private static void DebugEngineUpdate()
    {
        if(IsKeyReleased(KeyboardKey.KEY_GRAVE))
        {
            SetDebugPanelsStates(DebugPanelsState = !DebugPanelsState);
        }
    }

    #endregion

    #region Log Writer
    /// <summary> Every line ever written to the console</summary>
    private static List<string> lines = new List<string>();

    /// <summary> Used for the writing of logs to a file at the end of the game </summary>
    private static void WriteLogs()
    {
        DebugEngine.Log("Settings Log Writer Variables");
        string currentDay = DateTime.Now.ToString("yyyy-MM-dd");
        string currentTime = DateTime.Now.ToString("h-mm-ss tt");

        string directoryPath = $"Logs/{currentDay}";
        string filePath = $"{directoryPath}/{currentTime}.txt";

        DebugEngine.Log("Create File Paths for Log Writer");
        if(!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if(!File.Exists(filePath))
            File.Create(filePath).Dispose();

        DebugEngine.Log("Starting Log Writer");

        using(StreamWriter writer = new StreamWriter(filePath))
        {
            if(lines == null)
                return;

            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }
        }

        DebugEngine.Log("Stopping Log Writer");

    }


    #endregion

    #region Debug Panels

    /// <summary> Sets the active state for all the debug panels</summary>
    private static void SetDebugPanelsStates(bool state)
    {
        foreach (var panel in DebugPanels)
        {
            panel.Open = state;
        }
    }

    /// <summary> Adds a new Debug Panel to the lists</summary>
    public static void LoadDebugPanels(Panel panel)
    {
        DebugPanels.Add(panel);
        UIEngine.AddPanel(panel);
    }

    #endregion

    #region Logs

    /// <summary> Write a log the the console </summary>
    public static void Log(string message)
    {
        if(ShowLogs)
            WriteConsoleMessage(ConsoleColor.DarkGray, $"[Engine Log] {message}");
    }

    /// <summary> Write a error to the console</summary>
    public static void LogError(string message)
    {
        if(ShowErrorsLogs)
            WriteConsoleMessage(ConsoleColor.Red, $"[Engine Error] {message}");
    }

    /// <summary> Write a warning to the console </summary>
    public static void LogWarning(string message)
    {
        if(ShowWarningLogs)
            WriteConsoleMessage(ConsoleColor.Yellow, $"[Engine Warning] {message}");
    }

    /// <summary> Writes an important log to the console </summary>
    public static void LogImportant(string message)
    {
        if(ShowImportantLogs)
            WriteConsoleMessage(ConsoleColor.Gray, $"[Engine Log] {message}");
    }

    /// <summary> Writes a message to the console with a set color </summary>
    private static void WriteConsoleMessage(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;

        Console.WriteLine(message);
        lines?.Add(message);

        Console.ForegroundColor = ConsoleColor.White;
    }

    #endregion
}

}