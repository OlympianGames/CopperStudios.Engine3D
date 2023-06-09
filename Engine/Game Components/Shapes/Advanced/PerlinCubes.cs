using CopperStudios.Tools;
using CopperStudios.Engine;

using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;


/// <summary> Uses primitive cubes to show perlin noise. Also showcase of adding a Ui panel for variable editing. </summary>
public class PerlinCubes : GameObject
{
    public Vector3 offset = new Vector3(0, 0, 0);
    public float scale = 1;

    public int seed;
    public SimpleNoise noise = new SimpleNoise(0);

    public bool timeOffset = true;

    public PerlinCubes(string name = "Perlin Cubes")
    {
        this.name = name;
    }

    public List<CubePrimitive> cubes = new List<CubePrimitive>();
    public float gridSize = 50;

    public override void Start()
    {
        RegisterUIPanel(new PerlinCubesPanel(this));

        cubes = new List<CubePrimitive>();
        
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                CubePrimitive cube = new CubePrimitive($"Perlin Cube");
                cubes.Add(cube);

                Vector3 pos = cube.transform.position;
                pos.Z = z;
                pos.X = x;
                cube.transform.position = pos;
                
                RegisterGameObject(cube);
            }
        }
    }

    float timeOS;

    public override void Update()
    {
        if(timeOffset)
            timeOS = TimeEngine.time;
            
        for (int i = 0; i < cubes.Count; i++)
        {
            CubePrimitive cube = cubes[i];
            Vector3 pos = cube.transform.position;
            
            pos.Y = 
            (
                noise.Generate
                (
                    (pos.X + offset.X) + timeOS, 
                    (pos.Z + offset.Z) + timeOS
                ) + offset.Y
            ) * scale;

            cube.transform.position = pos;
        }
    }
}