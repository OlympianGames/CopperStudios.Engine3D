using System.Numerics;
using CopperStudios.Engine;
using ImGuiNET;
namespace CopperStudios.UI;

/// <summary> ImGUI Ui Window</summary>
public class UIPanel : Panel
{
    /// <summary> Name of the UI panel </summary>
    public string name;

    public UIPanel(string name = "unset")
    {
        this.name = name;
    }

    /// <summary> Attaches the panel to the UIEngine</summary>
    public override void Attach()
    {
        DebugEngine.Log($"Attached Panel - '{name}'");
        Open = true;
    }

    /// <summary> Detaches the panel from the UIEngine</summary>
    public override void Detach()
    {
        DebugEngine.Log($"Detached Panel - '{name}'");
        Open = false;
    }

    /// <summary> Renders the Base of the UI for internal uses</summary>
    public override void Render()
    {
        bool isOpen = Open;
        if (!isOpen) return;

        if (ImGui.Begin(name, ref isOpen))
        {
            UIUpdate();
        }

        if (!isOpen) Detach();
    }

    /// <summary> Update function for inherited classes to override for writing ImGUI functions </summary>
    public virtual void UIUpdate()
    {

    }

    /// <summary> Update function for inherited classes to override for updating values</summary>
    public override void Update()
    {
        
    }

    // Helpers

    /// <summary> Helper function for adding space</summary>
    protected void Spacer(bool showSlider, float amount)
    {
        if(showSlider)
            ImGui.Dummy(new Vector2(0, amount));
    }

    /// <summary> Helper function for either showing a slider or input for floats based on a bool</summary>
    protected void FloatInput(string label, ref float input, bool showSliders, float sliderMin, float sliderMax)
    {
        if(!showSliders)
            ImGui.InputFloat(label, ref input);

        if(showSliders)
            ImGui.SliderFloat(label, ref input, sliderMin, sliderMax);
    }

    /// <summary> Helper function for either showing sliders or inputs for Vector3s based on a bool</summary>
    protected void Float3Input(string label, ref Vector3 input, bool showSliders, float sliderMin, float sliderMax)
    {
        if(!showSliders)
            ImGui.InputFloat3(label, ref input);

        if(showSliders)
        {
            Spacer(showSliders, 1);
            ImGui.SliderFloat($"{label} X", ref input.X, sliderMin, sliderMax);
            Spacer(showSliders, 0.5f);
            ImGui.SliderFloat($"{label} Y", ref input.Y, sliderMin, sliderMax);
            Spacer(showSliders, 0.5f);
            ImGui.SliderFloat($"{label} Z", ref input.Z, sliderMin, sliderMax);
            Spacer(showSliders, 1);
        }
    }

    /// <summary> Helper function for either showing sliders or inputs for Ints based on a bool</summary>
    protected void IntInput(string label, ref int input, bool showSliders, int sliderMin, int sliderMax)
    {
        if(!showSliders)
            ImGui.InputInt(label, ref input);

        if(showSliders)
            ImGui.SliderInt(label, ref input, sliderMin, sliderMax);
    }
}