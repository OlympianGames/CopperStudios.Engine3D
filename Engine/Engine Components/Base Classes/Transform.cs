using System.Numerics;
namespace CopperStudios.Engine;

/// <summary> Transform for storing position, rotation, and scale </summary>
public class Transform
{
    /// <summary> World position of the transform</summary>
    public Vector3 position { get; set; } = Vector3.Zero;

    /// <summary> Rotation of the transform</summary>
    public Vector3 rotation { get; set; } = Vector3.Zero;
    
    /// <summary> Size of the transform</summary>
    public Vector3 scale { get; set; } = Vector3.One;
}