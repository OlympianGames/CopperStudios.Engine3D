using System.Text.Json;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using CopperStudios.Tools;

namespace CopperStudios.Engine;

/// <summary> Engine for rendering and loading models </summary>
public static class ModelEngine
{
    /// <summary> List of all loaded models </summary>
    public static List<ModelData> models = new List<ModelData>();

    /// <summary> Starts the Model Engine </summary>
    public static void StartEngine()
    {
        DebugEngine.Log("Starting Model Engine");

        Program.EngineDrawUpdate += DrawUpdate;
        DebugEngine.Log("Loading Dynamic Models");
        LoadDynamicModels();
        
        DebugEngine.Log("Model Engine Started");
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
            DrawModel(data.model, data.transform.position, 1f, Color.WHITE);
            // DebugEngine.Log(data.ToString());
        }
    }

    public static void LoadDynamicModels()
    {
        string[] files = System.IO.Directory.GetFiles($"Game/Resources/Dynamic Data/models", "*.json", SearchOption.AllDirectories);

        DebugEngine.Log($"Found {files.Count()} dynamic models");


        foreach (var file in files)
        {
            string json = File.ReadAllText(file);
            DynamicModelData? dynamicData= JsonSerializer.Deserialize<DynamicModelData>(json);

            DebugEngine.Log($"Loading dynamic model from '{file}' ");

            if(dynamicData == null)
                return;

            

            if(dynamicData.loadModel)
                LoadDynamicModel(dynamicData);
            else
                DebugEngine.Log($"Model {dynamicData.modelName} does not wish to be loaded");            
        }
    }

    public static void LoadDynamicModel(DynamicModelData dynamicData)
    {
        ModelData modelData = new ModelData();
        modelData.name = dynamicData.modelName;
        modelData.modelPath = dynamicData.modelPath;
        modelData.transform.position = dynamicData.position.ToVector3();

        LoadModel(modelData);
                
        DebugEngine.Log($"Loaded dynamic model {modelData.name}");
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
    public string name { get; set; } = "";
    /// <summary> Path of the model</summary>
    public string modelPath { get; set; } = "";
    /// <summary> Raylib model data </summary>
    public Model model { get; set; }
    /// <summary> Transform of the model - only position is used currently </summary>
    public Transform transform { get; set; } = new Transform();

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}


public class DynamicModelData
{
    public string modelName { get; set; } = "";
    public string modelPath { get; set; } = "";
    public SerializedVector3 position { get; set; } = new SerializedVector3(0, 0, 0);
    public bool loadModel { get; set; } = true;
}