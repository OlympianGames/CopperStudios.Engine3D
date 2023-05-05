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
    public float lerpSpeed = 1;

    public float gridSize = 50;

    public SineCubes(string name = "Sine Cubes")
    {
        this.name = name;
    }

    public List<GameObject> cubes = new List<GameObject>();

    public override void Start()
    {
        RegisterUIPanel(new SineCubesPanel(this));

        cubes = new List<GameObject>();
        
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {

                // CubeMeshPrimitive cube = new CubeMeshPrimitive($"Sine Cube");
                CubePrimitive cube = new CubePrimitive($"Sine Cube");
                cubes.Add(cube);

                Vector3 pos = cube.transform.position;
                pos.Z = z;
                pos.X = x;
                cube.transform.position = pos;
                
                RegisterGameObject(cube);
            }
        }
    }

    public override void Update()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            GameObject cube = cubes[i];
            Vector3 pos = cube.transform.position;

            pos.Y = CopperFloatMath.Lerp(pos.Y, MathF.Sin((TimeEngine.time + pos.X + pos.Z) * speed) * amplitude, lerpSpeed * TimeEngine.deltaTime);

            cube.transform.position = pos;
        }
    }
}