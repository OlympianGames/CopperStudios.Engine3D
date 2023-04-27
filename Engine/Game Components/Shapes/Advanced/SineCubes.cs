using CopperStudios.Tools;
using CopperStudios.Engine;

using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;


/// <summary> Uses primitive cubes to display a sine wave. Also a showcase of adding a Ui panel for variable editing. </summary>
public class SineCubes : GameObject
{
    public float speed = 1;
    public float amplitude = 1;

    public SineCubes(string name = "Sine Cubes")
    {
        this.name = name;
    }

    public List<CubePrimitive> cubes = new List<CubePrimitive>();

    public override void Start()
    {
        RegisterUIPanel(new SineCubesPanel(this));

        cubes = new List<CubePrimitive>();
        
        for (int x = 0; x < 9; x++)
        {
            for (int z = 0; z < 9; z++)
            {
                CubePrimitive cube = new CubePrimitive($"Sine Cube");
                cubes.Add(cube);
                cube.transform.position.Z = z-4;
                cube.transform.position.X = x-4;
                RegisterGameObject(cube);
            }
        }
    }

    public override void Update()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            CubePrimitive cube = cubes[i];
            Vector3 pos = cube.transform.position;

            pos.Y = MathF.Sin((TimeEngine.time + pos.X + pos.Z) * speed) * amplitude;

            cube.transform.position = pos;
        }
    }
}