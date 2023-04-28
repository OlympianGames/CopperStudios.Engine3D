using Raylib_cs;
using static Raylib_cs.Raylib;

using CopperStudios.Engine;
using CopperStudios.Tools;

/// <summary> Primitive cube gameobject </summary>
public class CubeMeshPrimitive : GameObject
{
    public Color baseColor = Color.DARKGRAY;

    // var testCube = loadModelFromMesh(genMeshCube(2.0, 2.0, 2.0))

    // var cubePosition = (0.0, 0.0, 0.0)

    // var xRotation, yRotation = 0.0

    // In game loop (as part of the updates):

    // xRotation += 0.02

    // yRotation += 0.02

    // testCube.transform = rotateXYZ(Vector3(x: xRotation, y: yRotation, z: 0.0))

    // In game loop (inside beginMode3d()):

    // drawModel(testCube, cubePosition, 1.0, Blue)

    Model model;

    public override void Start()
    {
        model = LoadModelFromMesh(GenMeshCube(transform.scale.X, transform.scale.Y, transform.scale.Z));
        
    }

    public override void Update()
    {
        model.transform = Raymath.MatrixRotateXYZ(transform.rotation);
    }

    public override void DrawUpdate()
    {
        DrawModel(model, transform.position, transform.scale.Magnitude(), baseColor);
    }

    public CubeMeshPrimitive(string name = "Cube Mesh Primitive")
    {
        this.name = name;
        this.transform = new CopperStudios.Engine.Transform();
    }
}