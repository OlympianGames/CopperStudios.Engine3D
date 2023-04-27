using CopperStudios.UI;
using static CopperStudios.UI.UiManager;

namespace CopperStudios.Engine
{

/// <summary> Engine for the UI. Mostly a middle man for naming sakes for ImGUI Ui </summary>
public static class UIEngine
{
    /// <summary> Start the UI Engine</summary>
    public static void StartUI()
    {
        Setup();
    }

    /// <summary> Renders the UI </summary>
    public static void Update()
    {
        Render();
    }

    /// <summary> Stops the UI </summary>
    public static void StopUI()
    {
        Shutdown();
    }

    /// <summary> Adds a new UI Panel</summary>
    public static void AddPanel(Panel panel)
    {
        PanelsToActivate.Add(panel);
    }
}

}