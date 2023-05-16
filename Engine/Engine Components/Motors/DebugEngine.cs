using CopperStudios.UI;
using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Text.Json.Serialization;

namespace CopperStudios.Engine;

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


    // Data
    /// <summary> Every line ever written to the console</summary>
    public static List<string> logLines { get; private set; } = new List<string>();


    // Debug Panels
    /// <summary> List of debug panels for toggling with a keybind</summary>
    private static List<Panel> DebugPanels = new List<Panel>();
    /// <summary> Current state of debug panels </summary>    
    private static bool DebugPanelsState;

    #region Engine Internal
    /// <summary> Starting the debug engine </summary>
    public static void StartDebugEngine()
    {
        DebugEngine.Log("Starting Debug Engine");
        
        DebugEngine.Log("Connecting Update Action");
        Program.EngineUpdate += DebugEngineUpdate;

        DebugEngine.Log("Debug Engine Started");
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
            if(logLines == null)
                return;

            foreach (var line in logLines)
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
        DebugEngine.Log($"Loading new Debug Panel");
        DebugPanels.Add(panel);
        UIEngine.AddPanel(panel);
    }

    #endregion

    #region Logs

    /// <summary> Write a log the the console </summary>
    public static void Log(string message = "", bool showTitle = true)
    {
        if(ShowLogs)
            WriteConsoleMessage(new LogData("[Log]", message, ConsoleColor.DarkGray, showTitle));
    }

    /// <summary> Write a error to the console</summary>
    public static void LogError(string message = "", bool showTitle = true)
    {
        if(ShowErrorsLogs)
            WriteConsoleMessage(new LogData("[Error]", message, ConsoleColor.Red, showTitle));
    }

    /// <summary> Write a warning to the console </summary>
    public static void LogWarning(string message = "", bool showTitle = true)
    {
        if(ShowWarningLogs)
            WriteConsoleMessage(new LogData("[Warning]", message, ConsoleColor.Yellow, showTitle));
    }

    /// <summary> Writes an important log to the console </summary>
    public static void LogImportant(string message = "", bool showTitle = true)
    {
        if(ShowImportantLogs)
            WriteConsoleMessage(new LogData("[Important]", message, ConsoleColor.Gray, showTitle));
    }

    /// <summary> Writes a message to the console via a LogData input class </summary>
    public static void WriteConsoleMessage(LogData data)
    {
        Console.ForegroundColor = data.color;

        string message = data.GetMessage();
        Console.WriteLine(message);
        logLines.Add(message);

        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary> Data class for custom log messages via the Debug Engine</summary>
    [System.Serializable]
    public class LogData
    {
        
        /// <summary> Title for the log. First thing shown in the log as '[title] message' </summary>
        public string title { get; set; } = "";
        /// <summary> Actual message for the log. Second thing shown in the log as '[title] message' </summary>
        public string message { get; set; } = "";
        /// <summary> If enabled, the title will actually be logged </summary>
        public bool showTitle { get; set; } = true;
        /// <summary> Color of the console message </summary>
        public ConsoleColor color { get; set; } = ConsoleColor.White;

        /// <summary> Empty constructor </summary>
        public LogData() {}

        /// <summary> Full constructor </summary>
        [JsonConstructor]
        public LogData(string title, string message, ConsoleColor color, bool showTitle = true)
        {
            this.color = color;
            this.title = title;
            this.message = message;
            this.showTitle = showTitle;
        }

        /// <summary> Gets the log message for the Debug Engine to actually log </summary>
        public string GetMessage()
        {
            if(string.IsNullOrEmpty(message))
                return "";
            else if(!showTitle)
                return message;
            else
                return $"{title} {message}";
        }
    }

    #endregion
}
