using Raylib_cs;
using System.Diagnostics;
using static System.Threading.Thread;
using static Raylib_cs.Raylib;
using CopperStudios.Engine;

namespace CopperStudios.Tools
{

public static class SamSound
{
    // sam
    public static Process SAM = new Process();
    public static Process sam { get => SAM; private set => SAM = value;}

    // values
    public static float mouth = 128;
    public static float throat = 128;
    public static float pitch = 64;
    public static float speed = 72;

    private static void StartSam()
    {
        sam.StartInfo.FileName = "sam/sam.exe";

        if(!Directory.Exists("sam"))
            Directory.CreateDirectory("sam");

        if(!Directory.Exists("sam/audios"))
            Directory.CreateDirectory("sam/audios");
    }

    public static void PlaySAMAudio(string text = "error")
    {
        string audioPath = "sam/audios";
        string fileName = $"{text}_audio.wav";
        fileName = String.Concat(fileName.Where(c => !Char.IsWhiteSpace(c)));
        string fullPath = $"{audioPath}/{fileName}";
     
        sam.StartInfo.Arguments = $"-mouth {mouth} -throat {throat} -pitch {pitch} -speed {speed} -wav {fullPath} {text}";
        sam.Start();

        Sleep(250);
        
        Sound sound = SoundEngine.LoadSound(fullPath, text);
        PlaySound(sound);
    }

    private static void StopSam()
    {
        foreach (FileInfo file in new DirectoryInfo("sam/audios").GetFiles())
        {
            file.Delete(); 
        }
    }
}

}