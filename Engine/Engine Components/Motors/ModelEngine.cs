using System.Text.Json;
using static Raylib_cs.Raylib;
using Raylib_cs;

namespace CopperStudios.Engine;

/// <summary> Engine for rendering and loading models </summary>
public static class ModelEngine
{
    /// <summary> List of all loaded models </summary>
    public static List<ModelData> models = new List<ModelData>();

    /// <summary> Starts the Model Engine </summary>
    public static void StartEngine()
    {
        Program.EngineDrawUpdate += DrawUpdate;
    }

    /// <summary> Stops the Model Engine </summary>
    public static void StopEngine()
    {
        Program.EngineDrawUpdate -= DrawUpdate;
    }

    /// <summary> Update for drawing the models </summary>
    public static void DrawUpdate()
    {
        foreach (var data in models)
        {
            DrawModel(data.model, data.transform.position, 1, Color.WHITE);
        }
    }

    /// <summary> Returns a ModelData and loads it to the game via a path and name </summary>
    public static ModelData LoadModel(string path, string name = "unset")
    {
        ModelData model = new ModelData
        {
            name = name,
            modelPath = path,
        };

        ModelEngine.LoadModel(model);
        return model;
    }

    /// <summary> Loads a model from a ModelData</summary>
    public static void LoadModel(ModelData data)
    {
        DebugEngine.Log($"Loading model - {data.name}");
        data.model = Raylib.LoadModel(data.modelPath);
        models.Add(data);
    }
}

/// <summary> Data for loading and rendering a model</summary>
public class ModelData
{
    /// <summary> Name of the model</summary>
    public string name = "";
    /// <summary> Path of the model</summary>
    public string modelPath = "";
    /// <summary> Raylib model data </summary>
    public Model model;
    /// <summary> Transform of the model - only position is used currently </summary>
    public Transform transform = new Transform();
}