using Raylib_cs;
using static Raylib_cs.Raylib;

using CopperStudios.Engine;

/// <summary> Primitive sphere game object</summary>
public class SpherePrimitive : GameObject
{
    public float radius;

    public Color baseColor = Color.DARKGRAY;
    public Color edgeColor = Color.BLACK;
    
    public override void DrawUpdate()
    {
        DrawSphere(transform.position, radius, baseColor);
        // TODO Fix wire sphere
        // DrawSphereWires(transform.position, radius, edgeColor);
    }

    public SpherePrimitive(string name = "Sphere Primitive")
    {
        this.name = name;
        this.transform = new CopperStudios.Engine.Transform();
    }
}