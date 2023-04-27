using System.Numerics;
using CopperStudios.Engine;
using CopperStudios.UI;
using ImGuiNET;

/// <summary> Ui panel for sine cubes gameobject</summary>
public class SineCubesPanel : UIPanel
{
    public SineCubes sineCubes;

    private bool showSliders = false;
    private bool showBoxPos = false;

    public SineCubesPanel(SineCubes sineCubes, string name = "Sine Cubes Panel")
    {
        this.name = name;
        this.sineCubes = sineCubes;
    }

    public override void UIUpdate()
    {
        ImGui.Separator();

        ImGui.Checkbox("Show Sliders", ref showSliders);
        ImGui.Checkbox("Show Box Positions", ref showBoxPos);

        ImGui.Separator();

        if(!showSliders)
        {
            ImGui.InputFloat("Speed", ref sineCubes.speed);
            ImGui.InputFloat("Amplitude", ref sineCubes.amplitude);
        }

        if(showSliders)
        {
            ImGui.SliderFloat("Speed", ref sineCubes.speed, -25, 25);
            ImGui.SliderFloat("Amplitude", ref sineCubes.amplitude, -25, 25);
        }

        ImGui.Separator();


        if(showBoxPos)
        {
            foreach (var cube in sineCubes.cubes)
            {
                Vector3 pos = cube.transform.position;
                ImGui.InputFloat3("", ref pos);
            }
        }
    }

    public override void Update()
    {
        
    }
}