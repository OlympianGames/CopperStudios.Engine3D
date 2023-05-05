using Raylib_cs;
using static Raylib_cs.Raylib;

namespace CopperStudios.Engine
{

/// <summary> Engine for playing and loading sounds </summary>
public static class SoundEngine
{
    /// <summary> List off all loaded sounds</summary>
    public static List<LoadedSound> loadedSounds = new List<LoadedSound>();

    /// <summary> Starts the audio engine</summary>
    public static void StartAudio()
    {
        DebugEngine.Log("Starting Sound Engine");
        
        DebugEngine.Log("Initiated Raylib Audio Device");
        InitAudioDevice();

        DebugEngine.Log("Sound Engine Started");
    }

    /// <summary> Stops the audio engine </summary>
    public static void StopAudio()
    {
        foreach (var sound in loadedSounds)
        {
            UnloadSound(sound.sound);
            DebugEngine.Log($"Unloaded Sound '{sound.name}'");
        }

        loadedSounds.Clear();

        CloseAudioDevice();
        DebugEngine.Log("Closed Audio Device");
    }

    /// <summary> Load a sound via a path. Adds the sound to a list and returns the sound </summary>
    public static Sound LoadSound(string path, string name = "unset")
    {
        LoadedSound loadedSound = new LoadedSound();
        loadedSound.sound = Raylib.LoadSound(path);
        loadedSound.name = name;
        loadedSounds.Add(loadedSound);

        DebugEngine.Log($"Loaded Sound '{name}' from '{path}' ");

        return loadedSound.sound;
    }

    public struct LoadedSound
    {
        public string name;
        public Sound sound;
    }
}

}