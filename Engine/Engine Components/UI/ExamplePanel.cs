using CopperStudios.Engine;
using ImGuiNET;
using Raylib_cs;

namespace CopperStudios.UI.Old;

public class ExamplePanel : Panel
{
    private Texture2D _texture;
    private float _time;

    private string name = "Example Window";

    public ExamplePanel(string name)
    {
        this.name = name;
    }

    public override void Attach()
    {
        DebugEngine.Log("Attached Example Panel");
        Open = true;
    }

    public override void Detach()
    {
        DebugEngine.Log("Detached Example Panel");
        Open = false;
    }

    public override void Render()
    {
        bool isOpen = Open;
        if (!isOpen) return;

        if (ImGui.Begin(name, ref isOpen))
        {
            ImGui.Text("Here's some text.");
            ImGui.Text("Have an image too!");
            ImGui.End();
        }

        if (!isOpen) Detach();
    }

    public override void Update()
    {
        Raylib.UnloadTexture(_texture);
        _time += Raylib.GetFrameTime();
        int c = (int) (255 * (Math.Sin(_time) + 1) / 2);
        Image image = Raylib.GenImageColor(640, 480, new Color(c, c, c, 255));
        _texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
    }
}