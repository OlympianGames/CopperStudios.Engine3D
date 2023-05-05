using CopperStudios.Tools;
using CopperStudios.Engine;

using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

/// <summary> Basic camera controller gameobject </summary>
public class CameraController : GameObject
{
    /// <summary> Default move speed for the camera</summary>
    public float moveSpeed = 5;

    /// <summary> Fast move speed for the camera. Activated via left shift by default </summary>
    public float fastSpeed = 20;

    /// <summary> Offset the camera target look position has from the cameras position</summary>
    public Vector3 targetOffset = new Vector3(0, -10, -10);

    public CameraController(string name = "Camera Controller")
    {
        this.name = name;
    }

    public override void Update()
    {
        UpdateCameraPosition();
    }

    /// <summary> Updates the position of the camera</summary>
    private void UpdateCameraPosition()
    {
        Vector3 position = Program.camera.position;
        float speed = moveSpeed;

        if(IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            speed = fastSpeed;
        else
            speed = moveSpeed;
            

        if(IsKeyDown(KeyboardKey.KEY_S))
            position.Z += speed * TimeEngine.deltaTime;

        if(IsKeyDown(KeyboardKey.KEY_W))
            position.Z -= speed * TimeEngine.deltaTime;

        if(IsKeyDown(KeyboardKey.KEY_D))
            position.X += speed * TimeEngine.deltaTime;

        if(IsKeyDown(KeyboardKey.KEY_A))
            position.X -= speed * TimeEngine.deltaTime;

        if(IsKeyDown(KeyboardKey.KEY_SPACE))
            position.Y += speed * TimeEngine.deltaTime;

        if(IsKeyDown(KeyboardKey.KEY_LEFT_CONTROL))
            position.Y -= speed * TimeEngine.deltaTime;

        Program.camera.position = position;
        Program.camera.target = position + targetOffset;

        transform.position = position;

    }
}