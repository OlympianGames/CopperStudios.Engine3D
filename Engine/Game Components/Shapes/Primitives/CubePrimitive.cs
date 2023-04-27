using Raylib_cs;
using static Raylib_cs.Raylib;

using CopperStudios.Engine;

/// <summary> Primitive cube gameobject </summary>
public class CubePrimitive : GameObject
{
    public Color baseColor = Color.DARKGRAY;
    public Color edgeColor = Color.BLACK;
    public override void DrawUpdate()
    {
        DrawCubeV(transform.position, transform.scale, baseColor);
        DrawCubeWiresV(transform.position, transform.scale, edgeColor);
    }

    public CubePrimitive(string name = "Cube Primitive")
    {
        this.name = name;
        this.transform = new CopperStudios.Engine.Transform();
    }
}