using Raylib_cs;
using static Raylib_cs.Raylib;

using CopperStudios.Engine;
using System.Numerics;

/// <summary> Primitive plane gameobject</summary>
public class PlanePrimitive : GameObject
{
    public Color baseColor = Color.DARKGRAY;
    public override void DrawUpdate()
    {
        DrawPlane(transform.position, new Vector2(transform.scale.X, transform.scale.Z), baseColor);
    }

    public PlanePrimitive(string name = "Plane Primitive")
    {
        this.name = name;
        this.transform = new CopperStudios.Engine.Transform();
    }
}