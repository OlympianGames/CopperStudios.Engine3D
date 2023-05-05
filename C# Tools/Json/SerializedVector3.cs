using System.Numerics;
using System.Text.Json.Serialization;

namespace CopperStudios.Tools;

[Serializable]
public class SerializedVector3
{
    public float x { get; set; } = 0;
    public float y { get; set; } = 0;
    public float z { get; set; } = 0;

    [JsonConstructor]
    public SerializedVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public SerializedVector3(Vector3 vector3)
    {
        x = vector3.X;
        y = vector3.Y;
        z = vector3.Z;
    }
}