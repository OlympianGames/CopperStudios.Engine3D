using CopperStudios.UI;

namespace CopperStudios.Engine;

/// <summary>
/// Base class of all objects in the game. Majorty of things should inherit from here
/// </summary>
public abstract class GameObject
{
    /// <summary> Name of the gameobjects </summary>
    public string name = "unset";
    
    /// <summary> Gameobjects transform, for holdig the position, rotation, and scale </summary>
    public Transform transform = new Transform();


    public GameObject(string name = "unset")
    {
        this.name = name;
        this.transform = new Transform();
    }

    /// <summary>Called whenever a game object is registered to connect the abstract functions</summary>
    public void InitiateGameObject()
    {
        Program.GameStart += Start;
        Program.GameUpdate += Update;
        Program.GameUIUpdate += UIUpdate;
        Program.GameDrawUpdate += DrawUpdate;
        Program.GameEnd += End;

        if(Program.gameStartCalled) Start();
    }

    /// <summary> Registers a UI panel to be displayed via ImGUI</summary>
    public void RegisterUIPanel(UIPanel panel)
    {
        Program.RegisterUIPanel(panel);
    }

    /// <summary> Registers a new game objects </summary>
    public void RegisterGameObject(GameObject gameObject)
    {
        Program.RegisterGameObject(gameObject);
    }

    /// <summary> Removes a game object from its events being called </summary>
    public void DeRegisterGameObject(GameObject gameObject)
    {
        Program.DeRegisterGameObject(gameObject);
    }

    /// <summary> Called once at the start of the game </summary>
    public virtual void Start()
    {

    }

    /// <summary> Called first of all the updates used for changing values </summary>
    public virtual void Update()
    {
        
    }

    /// <summary> Called second of all the updates for drawing/updating UI</summary>
    public virtual void UIUpdate()
    {

    }

    /// <summary> Called last of all the updates for drawing game objects</summary>
    public virtual void DrawUpdate()
    {

    }

    /// <summary> Called once at the end of the game </summary>
    public virtual void End()
    {

    }
}