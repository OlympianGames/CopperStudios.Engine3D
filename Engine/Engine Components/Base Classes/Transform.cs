using System.Numerics;
namespace CopperStudios.Engine;

/// <summary> Transform for storing position, rotation, and scale </summary>
public class Transform
{
    /// <summary> World position of the transform</summary>
    public Vector3 position = Vector3.Zero;

    /// <summary> Rotation of the transform</summary>
    public Vector3 rotation = Vector3.Zero;
    
    /// <summary> Size of the transform</summary>
    public Vector3 scale = Vector3.One;


    
}