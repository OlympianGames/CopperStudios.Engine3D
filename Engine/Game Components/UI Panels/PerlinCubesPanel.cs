using System.Numerics;
using CopperStudios.Engine;
using CopperStudios.UI;
using ImGuiNET;

/// <summary> Ui panel for perlin cubes gameobject</summary>
public class PerlinCubesPanel : UIPanel
{
    public PerlinCubes perlinCubes;

    private bool showSliders = false;
    private bool showBoxPos = false;

    public PerlinCubesPanel(PerlinCubes perlinCubes, string name = "Perlin Cubes Panel")
    {
        this.name = name;
        this.perlinCubes = perlinCubes;
    }

    public override void UIUpdate()
    {
        ImGui.Separator();

        ImGui.Checkbox("Show Sliders", ref showSliders);
        ImGui.Checkbox("Show Box Positions", ref showBoxPos);

        ImGui.Separator();

        ImGui.Checkbox("Time Offset", ref perlinCubes.timeOffset);
        
        SeedSetter();
        FloatInput("Scale", ref perlinCubes.scale, showSliders, -100, 100);
        Float3Input("Offset", ref perlinCubes.offset, showSliders, -100, 100);

        ImGui.Separator();

        if(showBoxPos)
        {
            foreach (var cube in perlinCubes.cubes)
            {
                Vector3 pos = cube.transform.position;
                ImGui.InputFloat3("", ref pos);
            }
        }
    }

    private void SeedSetter()
    {
        int seed = perlinCubes.seed;

        if(!showSliders)
            ImGui.InputInt("Seed", ref seed);

        if(showSliders)
            ImGui.SliderInt("Seed", ref seed, -100, 100);

        if(seed != perlinCubes.seed)
        {
            perlinCubes.seed = seed;
            perlinCubes.noise.SetSeed(seed);
        }

    }

    public override void Update()
    {
        
    }
}