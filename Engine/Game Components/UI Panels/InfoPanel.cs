using CopperStudios.Engine;
using CopperStudios.UI;
using ImGuiNET;

using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;

/// <summary> Panel for showing debug info, like FPS, deltaTime, and camera settings </summary>
public class InfoPanel : UIPanel
{
    private bool showSliders = false;

    public InfoPanel(string name = "Info Panel")
    {
        this.name = name;
    }

    public override void UIUpdate()
    {
        ImGui.Separator();

        if(ImGui.CollapsingHeader("Draw Settings"))
        {
            ImGui.Checkbox("Show Sliders", ref showSliders);
        }

        ImGui.Separator();

        if(ImGui.CollapsingHeader("Game Stats"))
        {
            ImGui.Text($"FPS - {Raylib.GetFPS()}");
            ImGui.Text($"Delta Time - {TimeEngine.deltaTime}");
            ImGui.Text($"Time - {TimeEngine.time}");
        }

        ImGui.Separator();

        if(ImGui.CollapsingHeader("FPS Settings"))
        {
            TargetFPSSetter();
        }

        ImGui.Separator();

        if(ImGui.CollapsingHeader("Camera Settings"))
        {
            CameraSettings();
        }

        ImGui.Separator();

        if(ImGui.CollapsingHeader("Grid Settings"))
        {
            IntInput("Grid Slices", ref Game.gridSlices, showSliders, 0, 250);
            FloatInput("Grid Spacing", ref Game.gridSpacing, showSliders, 0, 5);
        }
    }

    private void TargetFPSSetter()
    {
        int currentTarget = Program.targetFPS;

        IntInput("Target FPS", ref currentTarget, showSliders, 0, 360);

        if(currentTarget != Program.targetFPS)
        {
            Program.targetFPS = currentTarget;
            Raylib.SetTargetFPS(currentTarget);
        }
    }

    private void CameraSettings()
    {
        Float3Input("Position", ref Program.camera.position, showSliders, -100, 100);
        Float3Input("Target Offset", ref Game.cameraController.targetOffset, showSliders, -25, 25);
        Float3Input("Target", ref Program.camera.target, showSliders, -100, 100);
        FloatInput("Fov", ref Program.camera.fovy, showSliders, 0, 180);
    }

    public override void Update()
    {
        
    }
}